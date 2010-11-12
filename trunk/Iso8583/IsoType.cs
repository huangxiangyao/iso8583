using System;
using System.Collections.Generic;
using System.Text;

namespace Solab.Iso8583
{
    /// <summary>
    /// Lists the available ISO8583 datatypes.
    /// </summary>
    public enum IsoType
    {
        /// <summary>
        /// A numeric value of a certain length, zero-padded to the left.
        /// </summary>
        NUMERIC = 0,
        /// <summary>
        /// An alphanumeric value of a certain length, space-padded to the right.
        /// </summary>
        ALPHA,
        /// <summary>
        /// A variable-length alphanumeric value, from 1 to 99 characters.
        /// </summary>
        LLVAR,
        /// <summary>
        /// A variable-length alphanumeric value, from 1 to 999 characters.
        /// </summary>
        LLLVAR,
        /// <summary>
        /// A date and time in format MMddHHmmss
        /// </summary>
        DATE10,
        /// <summary>
        /// A date in format MMdd
        /// </summary>
        DATE4,
        /// <summary>
        /// An expiration date (for a credit card, for example), in format YYmm
        /// </summary>
        DATE_EXP,
        /// <summary>
        /// The time of day, in format HHmmss
        /// </summary>
        TIME,
        /// <summary>
        /// A monetary amount, expressed in cents, with a fixed length of 12 positions, zero-padded to the left.
        /// </summary>
        AMOUNT
    }

    /// <summary>
    /// This convenience class implements some methods to ease the handling
    /// of IsoTypes.
    /// </summary>
    public abstract class IsoTypeHelper
    {

        /// <summary>
        /// Returns true if the IsoType is NUMERIC or ALPHA, since these two
        /// types need a length to be specified as part of a field.
        /// </summary>
        /// <param name="t">The type in question.</param>
        /// <returns>true if the IsoType needs a length specification to be stored as an IsoValue.</returns>
        public static bool NeedsLength(IsoType t)
        {
            return (t == IsoType.NUMERIC || t == IsoType.ALPHA);
        }

        /// <summary>
        /// Returns the length of a type, for types that always have the same
        /// length, of 0 in case of types that can have a variable length.
        /// </summary>
        /// <param name="t">The type in question.</param>
        /// <returns>The length of the type if it's a fixed-length type,
        /// or 0 if it's a variable-length type.</returns>
        public static int GetLength(IsoType t)
        {
            if (t == IsoType.DATE10)
            {
                return 10;
            }
            else if (t == IsoType.DATE4 || t == IsoType.DATE_EXP)
            {
                return 4;
            }
            else if (t == IsoType.TIME)
            {
                return 6;
            }
            else if (t == IsoType.AMOUNT)
            {
                return 12;
            }
            return 0;
        }

        /// <summary>
        /// Formats a DateTime of the specified IsoType as a string.
        /// </summary>
        /// <param name="d">A DateTime object.</param>
        /// <param name="t">An IsoType (must be DATE10, DATE4, DATE_EXP or TIME).</param>
        /// <returns>The date formatted as a string according to the specified IsoType.</returns>
        public static string Format(DateTime d, IsoType t)
        {
            if (t == IsoType.DATE10)
            {
                return d.ToString("MMddHHmmss");
            }
            else if (t == IsoType.DATE4)
            {
                return d.ToString("MMdd");
            }
            else if (t == IsoType.DATE_EXP)
            {
                return d.ToString("yyMM");
            }
            else if (t == IsoType.TIME)
            {
                return d.ToString("HHmmss");
            }
            throw new ArgumentException("IsoType must be DATE10, DATE4, DATE_EXP or TIME");
        }

        /// <summary>
        /// Formats a string to the given length, padding it if necessary.
        /// </summary>
        /// <param name="value">The string to format.</param>
        /// <param name="t">The ISO8583 type to format the string as.</param>
        /// <param name="length">The length (in case of ALPHA or NUMERIC).</param>
        /// <returns>The formatted string.</returns>
        public static string Format(string value, IsoType t, int length)
        {
            if (t == IsoType.ALPHA)
            {
                char[] c = new char[length];
                if (value == null)
                {
                    value = "";
                }
                else if (value.Length == length)
                {
                    return value;
                }
                else if (value.Length > length)
                {
                    return value.Substring(0, length);
                }
                Array.Copy(value.ToCharArray(), c, value.Length);
                for (int i = value.Length; i < length; i++)
                {
                    c[i] = ' ';
                }
                return new String(c);
            }
            else if (t == IsoType.LLVAR || t == IsoType.LLLVAR)
            {
                return value;
            }
            else if (t == IsoType.NUMERIC)
            {
                if (value.Length == length)
                {
                    return value;
                }
                char[] c = new char[length];
                char[] x = value.ToCharArray();
                if (x.Length > length)
                {
                    throw new ArgumentOutOfRangeException("Numeric value is larger than intended length");
                }
                int lim = c.Length - x.Length;
                for (int i = 0; i < lim; i++)
                {
                    c[i] = '0';
                }
                Array.Copy(x, 0, c, lim, x.Length);
                return new String(c);
            }
            throw new ArgumentException("IsoType must be ALPHA, LLVAR, LLLVAR or NUMERIC");
        }

        /// <summary>
        /// Formats a number as an ISO8583 type.
        /// </summary>
        /// <param name="value">The number to format.</param>
        /// <param name="t">The ISO8583 type to format the value as.</param>
        /// <param name="length">The length to format to (in case of ALPHA or NUMERIC)</param>
        /// <returns>The formatted string representation of the value.</returns>
        public static string Format(long value, IsoType t, int length)
        {
            if (t == IsoType.NUMERIC || t == IsoType.ALPHA)
            {
                return Format(value.ToString(), t, length);
            }
            else if (t == IsoType.LLLVAR || t == IsoType.LLVAR)
            {
                return value.ToString();
            }
            else if (t == IsoType.AMOUNT)
            {
                return value.ToString("0000000000") + "00";
            }
            throw new ArgumentException("IsoType must be AMOUNT, NUMERIC, ALPHA, LLLVAR or LLVAR");
        }

        /// <summary>
        /// Formats a decimal value as an ISO8583 type.
        /// </summary>
        /// <param name="value">The decimal value to format.</param>
        /// <param name="t">The ISO8583 type to format the value as.</param>
        /// <param name="length">The length for the formatting, useful if the type is NUMERIC or ALPHA.</param>
        /// <returns>The formatted string representation of the value.</returns>
        public static string Format(decimal value, IsoType t, int length)
        {
            if (t == IsoType.AMOUNT)
            {
                char[] x = value.ToString("0000000000.00").ToCharArray();
                char[] digits = new char[12];
                Array.Copy(x, digits, 10);
                Array.Copy(x, 11, digits, 10, 2);
                return new String(digits);
            }
            else if (t == IsoType.NUMERIC || t == IsoType.ALPHA)
            {
                return Format(value.ToString(), t, length);
            }
            else if (t == IsoType.LLVAR || t == IsoType.LLLVAR)
            {
                return value.ToString();
            }
            throw new ArgumentException("IsoType must be AMOUNT, NUMERIC, ALPHA, LLLVAR or LLVAR");
        }

    }

}
