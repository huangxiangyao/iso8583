using System;
using System.Collections.Generic;
using System.Text;

namespace Solab.Iso8583
{
    /// <summary>
    /// Defines the behavior needed to generate trace numbers. They have to
    /// be sequential and cyclical (after 999999, 1 must be returned). This
    /// is useful to generate a unique trace number for every message created;
    /// it usually goes in field 11 as a NUMERIC value of length 6.
    /// </summary>
    public interface ITraceGenerator
    {

        /// <summary>
        /// Returns the next trace number to be used in a message.
        /// </summary>
        int NextTrace();

        /// <summary>
        /// Returns the last trace number that was returned by the NextTrace()
        /// method.
        /// </summary>
        int LastTrace { get; }
    }

}
