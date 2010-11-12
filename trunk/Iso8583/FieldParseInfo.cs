using System;
using System.Collections.Generic;
using System.Text;
using Solab.Iso8583;

namespace Solab.Iso8583.Parsing
{

    /// <summary>
    /// This class stores the necessary information for parsing an ISO8583 field
    /// inside a message.
    /// </summary>
    public class FieldParseInfo
    {
        private IsoType type;
        private int length;

        /// <summary>
        /// Creates a new instance that knows how to parse a value of the given
        /// type and the given length (the length is necessary for ALPHA and NUMERIC
        /// values only).
        /// </summary>
        /// <param name="t">The ISO8583 type.</param>
        /// <param name="len">The length of the value to parse (for ALPHA and NUMERIC values).</param>
        public FieldParseInfo(IsoType t, int len)
        {
            type = t;
            length = len;
        }

        /// <summary>
        /// The field length to parse.
        /// </summary>
        public int Length
        {
            get { return length; }
        }

        /// <summary>
        /// The type of the value that will be parsed.
        /// </summary>
        public IsoType Type
        {
            get { return type; }
        }

        /// <summary>
        /// Parses a value of the type and length specified in the constructor
        /// and returns the IsoValue.
        /// </summary>
        /// <param name="buf">The byte buffer containing the value to parse.</param>
        /// <param name="pos">The position inside the byte buffer where the parsing must start.</param>
        /// <param name="encoder">The encoder to use for converting bytes to strings.</param>
        /// <returns>The resulting IsoValue with the given types and length, and the stored value.</returns>
        public IsoValue Parse(byte[] buf, int pos, Encoding encoder)
        {
            if (type == IsoType.NUMERIC || type == IsoType.ALPHA)
            {
                return new IsoValue(type, encoder.GetString(buf, pos, length), length);
            }
            else if (type == IsoType.LLVAR)
            {
                length = ((buf[pos] - 48) * 10) + (buf[pos + 1] - 48);
                if (length < 1 || length > 99)
                {
                    throw new ArgumentException("LLVAR field with invalid length");
                }
                return new IsoValue(type, encoder.GetString(buf, pos + 2, length));
            }
            else if (type == IsoType.LLLVAR)
            {
                length = ((buf[pos] - 48) * 100) + ((buf[pos + 1] - 48) * 10) + (buf[pos + 2] - 48);
                if (length < 1 || length > 999)
                {
                    throw new ArgumentException("LLLVAR field with invalid length");
                }
                return new IsoValue(type, encoder.GetString(buf, pos + 3, length));
            }
            else if (type == IsoType.AMOUNT)
            {
                byte[] c = new byte[13];
                Array.Copy(buf, pos, c, 0, 10);
                Array.Copy(buf, pos + 10, c, 11, 2);
                c[10] = (byte)'.';
                return new IsoValue(type, Decimal.Parse(encoder.GetString(c)));
            }
            else if (type == IsoType.DATE10)
            {
                DateTime dt = DateTime.Now;
                dt = new DateTime(dt.Year,
                    ((buf[pos] - 48) * 10) + buf[pos + 1] - 48,
                    ((buf[pos + 2] - 48) * 10) + buf[pos + 3] - 48,
                    ((buf[pos + 4] - 48) * 10) + buf[pos + 5] - 48,
                    ((buf[pos + 6] - 48) * 10) + buf[pos + 7] - 48,
                    ((buf[pos + 8] - 48) * 10) + buf[pos + 9] - 48);
                if (dt.CompareTo(DateTime.Now) > 0)
                {
                    dt.AddYears(-1);
                }
                return new IsoValue(type, dt);
            }
            else if (type == IsoType.DATE4)
            {
                DateTime dt = DateTime.Now;
                dt = new DateTime(dt.Year,
                    ((buf[pos] - 48) * 10) + buf[pos + 1] - 48,
                    ((buf[pos + 2] - 48) * 10) + buf[pos + 3] - 48);
                if (dt.CompareTo(DateTime.Now) > 0)
                {
                    dt.AddYears(-1);
                }
                return new IsoValue(type, dt);
            }
            else if (type == IsoType.DATE_EXP)
            {
                DateTime dt = DateTime.Now;
                dt = new DateTime(dt.Year - (dt.Year % 100) + ((buf[pos] - 48) * 10) + buf[pos + 1] - 48,
                    ((buf[pos + 2] - 48) * 10) + buf[pos + 3] - 48, 1);
                return new IsoValue(type, dt);
            }
            else if (type == IsoType.TIME)
            {
                DateTime dt = DateTime.Now;
                dt = new DateTime(dt.Year, dt.Month, dt.Day,
                    ((buf[pos] - 48) * 10) + buf[pos + 1] - 48,
                    ((buf[pos + 2] - 48) * 10) + buf[pos + 3] - 48,
                    ((buf[pos + 4] - 48) * 10) + buf[pos + 5] - 48);
                return new IsoValue(type, dt);
            }
            return null;
        }

    }

}
