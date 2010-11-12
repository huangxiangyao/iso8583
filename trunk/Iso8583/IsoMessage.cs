using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;

namespace Solab.Iso8583 {

	/// <summary>
	/// This class represents an ISO8583 Message. It contains up to 127 fields
	/// numbered from 2 to 128; field 1 is reserved for the secondary bitmap
	/// and the bitmaps are calculated automatically by the message when it is
	/// going to be written to a stream. It can be a binary or an ASCII message;
	/// ASCII messages write themselves as their string representations and
	/// binary messages can write binary values to the stream, encoding numeric
	/// values using BCD.
	/// </summary>
	public class IsoMessage {

        const string HEX = "0123456789ABCDEF";
        private int type;
		private bool binary;
		private Dictionary<int, IsoValue> fields = new Dictionary<int, IsoValue>();
		private String isoHeader;
		private int etx = -1;

		public IsoMessage() { }

		/// <summary>
		/// Creates a new instance with the specified header. This header
		/// will be written after the length and before the message type.
		/// </summary>
		/// <param name="header"></param>
		internal IsoMessage(String header) {
			isoHeader = header;
		}

		/// <summary>
		/// The ISO8583 message header, which goes after the length header
		/// and before the message type.
		/// </summary>
		public String IsoHeader { get { return isoHeader; } }

		/// <summary>
		/// The message type (0x200, 0x400, etc).
		/// </summary>
		public int Type {
			set { type = value; }
			get { return type; }
		}

		/// <summary>
		/// Indicates if the message is binary (true) or ASCII (false).
		/// </summary>
		public bool Binary {
			set { binary = value; }
			get { return binary; }
		}

		/// <summary>
		/// The optional END TEXT character, which goes at the end of the message.
		/// </summary>
		public int Etx {
			set { etx = value; }
			get { return etx; }
		}

		/// <summary>
		/// Returns the stored object value in a specified field. Fields
		/// are represented by IsoValues which contain objects so this
		/// method can return the contained objects directly.
		/// </summary>
		/// <param name="field">The field number (2 to 128)</param>
		/// <returns>The stored object value in that field, or null if the message does not have the field.</returns>
		public object GetObjectValue(int field) {
			IsoValue v = fields[field];
			if (v == null) {
				return null;
			}
			return v.Value;
		}

		/// <summary>
		/// Returns the IsoValue used in a field to contain an object.
		/// </summary>
		/// <param name="field">The field index (2 to 128).</param>
		/// <returns>The IsoValue for the specified field.</returns>
		public IsoValue GetField(int field) {
			return fields[field];
		}

		/// <summary>
		/// Stores the given IsoValue in the specified field index.
		/// </summary>
		/// <param name="index">The field index (2 to 128)</param>
		/// <param name="field">The IsoValue to store under that index.</param>
		public void SetField(int index, IsoValue field) {
			if (index < 2 || index > 128) {
				throw new ArgumentOutOfRangeException("Index must be between 2 and 128");
			}
			if (field == null) {
				fields.Remove(index);
			} else {
				fields[index] = field;
			}
		}

		/// <summary>
		/// Creates an IsoValue with the given values and stores it in the specified index.
		/// </summary>
		/// <param name="index">The field index (2 to 128)</param>
		/// <param name="value">An object value to store inside an IsoValue.</param>
		/// <param name="t">The ISO8583 for this value.</param>
		/// <param name="length">The length of the value (useful only for NUMERIC and ALPHA types).</param>
		public void SetValue(int index, object value, IsoType t, int length) {
			if (index < 2 || index > 128) {
				throw new ArgumentOutOfRangeException("Index must be between 2 and 128");
			}
			if (value == null) {
				fields.Remove(index);
			} else {
				IsoValue v = null;
				if (IsoTypeHelper.NeedsLength(t)) {
					v = new IsoValue(t, value, length);
				} else {
					v = new IsoValue(t, value);
				}
				fields[index] = v;
			}
		}

		/// <summary>
		/// Indicates if the message contains the specified field.
		/// </summary>
		/// <param name="idx">The field index (2 to 128)</param>
		/// <returns>true if the message is storing an IsoValue under that field index.</returns>
		public bool HasField(int idx) {
			return fields.ContainsKey(idx);
		}

		/// <summary>
		/// Writes the entire message to a stream, using the specified number
		/// of bytes to write a length header first.
		/// </summary>
		/// <param name="outs">The stream to write the message to.</param>
		/// <param name="lenBytes">The number of bytes to write the length of the message in. Can be anything from 1 to 4.</param>
		/// <param name="countEtx">Indicates if the ETX character (if present) should be counted as part of the message, for the length header.</param>
		public void Write(Stream outs, int lenBytes, bool countEtx) {
            if (lenBytes > 4) {
                throw new ArgumentException("Length header can have at most 4 bytes");
            }
            byte[] data = WriteInternal();
            if (lenBytes > 0) {
                int l = data.Length;
                if (etx > -1 && countEtx) {
                    l++;
                }
                byte[] buf = new byte[lenBytes];
                int pos = 0;
                if (lenBytes == 4) {
                    buf[0] = (byte)((l & 0xff000000) >> 24);
                    pos++;
                }
                if (lenBytes > 2) {
                    buf[pos] = (byte)((l & 0xff0000) >> 16);
                    pos++;
                }
                if (lenBytes > 1) {
                    buf[pos] = (byte)((l & 0xff00) >> 8);
                    pos++;
                }
                buf[pos] = (byte)(l & 0xff);
                outs.Write(buf, 0, buf.Length);
            }
            outs.Write(data, 0, data.Length);
			//ETX
            if (etx > -1) {
                outs.WriteByte((byte)etx);
            }
            outs.Flush();
		}

        protected byte[] WriteInternal() {
            MemoryStream ms = new MemoryStream(16);
            byte[] buf = null;
            if (isoHeader != null) {
                buf = Encoding.ASCII.GetBytes(isoHeader);
                ms.Write(buf, 0, buf.Length);
            }
            if (binary) {
                ms.WriteByte((byte)((type & 0xff00) >> 8));
                ms.WriteByte((byte)(type & 0xff));
            } else {
                String x = type.ToString("x4");
                ms.Write(Encoding.ASCII.GetBytes(x), 0, 4);
            }
            //TODO write the bitmap
            Dictionary<int, IsoValue>.KeyCollection keys = fields.Keys;
            BitArray bits = new BitArray(64);
            foreach (int i in keys) {
                if (i > 64) {
                    bits.Length = 128;
                    bits.Set(0, true);
                }
                bits.Set(i - 1, true);
            }
            if (binary) {
                buf = new byte[bits.Length / 8];
                bits.CopyTo(buf, 0);
            } else {
                buf = new byte[bits.Length / 4];
                int pos = 0;
                int lim = bits.Length / 4;
                for (int i = 0; i < lim; i++) {
                    int nibble = 0;
                    if (bits.Get(pos++))
                        nibble += 8;
                    if (bits.Get(pos++))
                        nibble += 4;
                    if (bits.Get(pos++))
                        nibble += 2;
                    if (bits.Get(pos++))
                        nibble++;
                    Encoding.ASCII.GetBytes(HEX, nibble, 1, buf, i);
                }
            }
            ms.Write(buf, 0, buf.Length);
            //Write each field
            for (int i = 1; i < bits.Length; i++) {
                if (fields.ContainsKey(i)) {
                    IsoValue v = fields[i];
                    v.Write(ms);
                }
            }
            return ms.ToArray();
        }

    }

}
