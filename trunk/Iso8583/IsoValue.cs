using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Solab.Iso8583
{

    /// <summary>
    /// Stores a value contained in a field inside a Message.
    /// </summary>
    public class IsoValue : ICloneable
    {
        private IsoType type;
        private int length;
        private object fval;

        /// <summary>
        /// Creates a new instance to store a value of a fixed-length type.
        /// Fixed-length types are DATE4, DATE_EXP, DATE10, TIME, AMOUNT.
        /// </summary>
        /// <param name="t">The ISO8583 type of the value that is going to be stored.</param>
        /// <param name="value">The value to store.s</param>
        public IsoValue(IsoType t, object value)
        {
            if (value == null)
            {
                throw new ArgumentException("Value cannot be null");
            }
            if (IsoTypeHelper.NeedsLength(t))
            {
                throw new ArgumentException("Use IsoValue constructor for Fixed-value types");
            }
            type = t;
            fval = value;
            if (t == IsoType.LLVAR || type == IsoType.LLLVAR)
            {
                length = value.ToString().Length;
            }
            else
            {
                length = IsoTypeHelper.GetLength(t);
            }
        }

        /// <summary>
        /// Creates a new instance to store a value of a given type. This constructor
        /// is used for variable-length types (LLVAR, LLLVAR, ALPHA, NUMERIC) -
        /// variable in the sense that that length of the value does not depend
        /// solely on the ISO type.
        /// </summary>
        /// <param name="t">the ISO8583 type of the value to be stored.</param>
        /// <param name="val">The value to be stored.</param>
        /// <param name="len">The length of the field.</param>
        public IsoValue(IsoType t, object val, int len)
        {
            if (val == null)
            {
                throw new ArgumentException("Value cannot be null");
            }
            type = t;
            fval = val;
            length = len;
            if (length == 0 && IsoTypeHelper.NeedsLength(t))
            {
                throw new ArgumentException("Length must be greater than zero");
            }
            else if (t == IsoType.LLVAR || t == IsoType.LLLVAR)
            {
                length = val.ToString().Length;
            }
        }

        /// <summary>
        /// The ISO8583 type of the value stored in the receiver.
        /// </summary>
        public IsoType Type
        {
            get { return type; }
        }

        /// <summary>
        /// The length of the field.
        /// </summary>
        public int Length
        {
            get { return length; }
        }

        /// <summary>
        /// The value stored in the receiver.
        /// </summary>
        public object Value
        {
            get { return fval; }
        }

        public override bool Equals(object other)
        {
            if (other == null || !(other is IsoValue))
            {
                return false;
            }
            IsoValue comp = (IsoValue)other;
            return (comp.Type == type && comp.Value.Equals(fval) && comp.Length == length);
        }

        public override int GetHashCode()
        {
            return fval.GetHashCode();
        }

        /// <summary>
        /// Returns the string representation of the stored value, which
        /// varies a little depending on its type: NUMERIC and ALPHA values
        /// are returned padded to the specified length of the field either
        /// with zeroes or spaces; AMOUNT values are formatted to 12 digits
        /// as cents; date/time values are returned with the specified format
        /// for their type. LLVAR and LLLVAR values are returned as they are.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (type == IsoType.NUMERIC || type == IsoType.ALPHA)
            {
                return IsoTypeHelper.Format(fval.ToString(), type, length);
            }
            else if (type == IsoType.AMOUNT)
            {
                if (fval is decimal)
                {
                    return IsoTypeHelper.Format((decimal)fval, type, 12);
                }
                else
                {
                    return IsoTypeHelper.Format(Convert.ToDecimal(fval), type, 12);
                }
            }
            else if (fval is DateTime)
            {
                return IsoTypeHelper.Format((DateTime)fval, type);
            }
            return fval.ToString();
        }

        /// <summary>
        /// Writes the stored value to a stream, preceded by the length header
        /// in case of LLVAR or LLLVAR values.
        /// </summary>
        /// <param name="outs"></param>
        public void Write(Stream outs)
        {
            //TODO binary encoding is pending
            String v = ToString();
            if (type == IsoType.LLVAR || type == IsoType.LLLVAR)
            {
                length = v.Length;
                if (length > 100)
                {
                    outs.WriteByte((byte)((length / 100) + 48));
                }
                else if (type == IsoType.LLLVAR)
                {
                    outs.WriteByte(48);
                }
                if (length >= 10)
                {
                    outs.WriteByte((byte)(((length % 100) / 10) + 48));
                }
                else
                {
                    outs.WriteByte(48);
                }
                outs.WriteByte((byte)((length % 10) + 48));
            }
            byte[] buf = Encoding.ASCII.GetBytes(v);
            outs.Write(buf, 0, buf.Length);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

    }

}
