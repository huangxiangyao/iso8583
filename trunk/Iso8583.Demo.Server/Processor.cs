using System;
using System.Text;
using System.Threading;
using Solab.Iso8583;
using System.IO;
using System.Net.Sockets;

namespace Tests
{
    class Processor
    {
        private byte[] msg;
        private TcpClient sock;
        MessageFactory mfact;

        public Processor(byte[] buf, TcpClient s, MessageFactory m)
        {
            msg = buf;
            sock = s;
            mfact = m;
        }

        public void Respond()
        {
            Thread.Sleep(400);
            try
            {
                Console.Out.WriteLine("Parsing incoming: {0}", Encoding.ASCII.GetString(msg));
                IsoMessage incoming = mfact.ParseMessage(msg, 12);
                //Create a response
                IsoMessage response = mfact.CreateResponse(incoming);
                response.SetField(11, incoming.GetField(11));
                response.SetField(7, incoming.GetField(7));
                response.SetValue(38, DateTime.Now.Ticks % 1000000, IsoType.NUMERIC, 6);
                response.SetValue(39, 0, IsoType.NUMERIC, 2);
                response.SetValue(61, "Dynamic data generated at " + DateTime.Now, IsoType.LLLVAR, 0);
                Console.Out.WriteLine("Sending response conf {0}", response.GetField(38));
                response.Write(sock.GetStream(), 2, true);
            }
            catch (IOException ex)
            {
                Console.Out.WriteLine("Sending response {0}", ex);
            }
        }
    }

}
