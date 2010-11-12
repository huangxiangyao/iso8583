using System;
using System.Collections.Generic;
using System.Text;

namespace Solab.Iso8583
{

    public class SimpleTraceGenerator : ITraceGenerator
    {
        private int value = 0;

        public SimpleTraceGenerator(int initialValue)
        {
            if (initialValue < 1 || initialValue > 999999)
            {
                throw new ArgumentException("initialValue must be between 1 and 999999", "initialValue");
            }
            value = initialValue;
        }

        public int LastTrace
        {
            get { return value; }
        }

        public int NextTrace()
        {
            lock (this)
            {
                value++;
                if (value > 999999)
                {
                    value = 1;
                }
                return value;
            }
        }
    }
}
