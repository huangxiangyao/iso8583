using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net.Sockets;
using Solab.Iso8583;
using Solab.Iso8583.Parsing;
using System.Threading;

namespace Tests {

    class Client {

        public static string[] data = new string[]{
		"1234567890", "5432198765", "1020304050", "abcdefghij", "AbCdEfGhIj",
		"1a2b3c4d5e", "A1B2C3D4E5", "a0c0d0f0e0", "j5k4m3nh45" };
        public static Decimal[] amounts = new Decimal[]{
		10M, 20.50M, 37.44M };
        private static MessageFactory mfact;
        private static Dictionary<String, IsoMessage> pending = new Dictionary<String, IsoMessage>();

        private TcpClient sock;

        public Client(TcpClient s) {
            sock = s;
        }

        public void Send() {
            byte[] lenbuf = new byte[2];
            try {
                //For high volume apps you will be better off only reading the stream in one thread
                //and then using another thread to parse the buffers and process the responses
                //Otherwise the network buffer might fill up and you can miss a message.
                while (sock != null && sock.Connected && Thread.CurrentThread.IsAlive) {
                    sock.GetStream().Read(lenbuf, 0, 2);
                    int size = ((lenbuf[0] & 0xff) << 8) | (lenbuf[1] & 0xff);
                    byte[] buf = new byte[size];
                    //We're not expecting ETX in this case
                    if (sock.GetStream().Read(buf, 0, size) == size) {
                            //We'll use this header length as a reference.
                            //In practice, ISO headers for any message type are the same length.
                            string respHeader = mfact.GetIsoHeader(0x200);
                            IsoMessage resp = mfact.ParseMessage(buf,
                                respHeader == null ? 12 : respHeader.Length);
                            Console.Out.WriteLine("Read response {0} conf {1}: {2}",
                                resp.GetField(11), resp.GetField(38), Encoding.ASCII.GetString(buf));
                            pending.Remove(resp.GetField(11).ToString());
                    } else {
                        Console.WriteLine("Incomplete input, exiting");
                        pending.Clear();
                        return;
                    }
                }
            } catch (IOException ex) {
                Console.Out.WriteLine("Reading responses {0}", ex);
            } finally {
                try {
                    sock.Close();
                } catch (IOException) { };
            }
        }

        [STAThread]
        public static void Main(string[] args) {
            Random rng = new Random((int)(DateTime.Now.Ticks & 0xffffffff));
            Console.Out.WriteLine("Reading config");
            mfact = ConfigParser.CreateFromFile("iso8583.xml");
            mfact.AssignDate = true;
            mfact.TraceGenerator = new SimpleTraceGenerator((int)(DateTime.Now.Ticks % 10000));
            Console.Out.WriteLine("Connecting to server");
            TcpClient sock = new TcpClient("192.168.0.2", 9999);
            //Send 10 messages, then wait for the responses
            Client reader = new Client(sock);
            Thread thread = new Thread(new ThreadStart(reader.Send));
            thread.Start();
            for (int i = 0; i < 10; i++) {
                IsoMessage req = mfact.NewMessage(0x200);
                req.SetValue(4, amounts[rng.Next(amounts.Length)], IsoType.AMOUNT, 0);
                req.SetValue(12, req.GetObjectValue(7), IsoType.TIME, 0);
                req.SetValue(13, req.GetObjectValue(7), IsoType.DATE4, 0);
                req.SetValue(15, req.GetObjectValue(7), IsoType.DATE4, 0);
                req.SetValue(17, req.GetObjectValue(7), IsoType.DATE4, 0);
                req.SetValue(37, DateTime.Now.Ticks % 1000000, IsoType.NUMERIC, 12);
                req.SetValue(41, data[rng.Next(data.Length)], IsoType.ALPHA, 16);
                req.SetValue(48, data[rng.Next(data.Length)], IsoType.LLLVAR, 0);
                pending[req.GetField(11).ToString()] = req;
                Console.Out.WriteLine("Sending request {0}", req.GetField(11));
                req.Write(sock.GetStream(), 2, false);
            }
            Console.Out.WriteLine("Waiting for responses");
            while (pending.Count > 0 && sock.Connected) {
                Thread.Sleep(500);
            }
            thread.Interrupt();
            sock.Close();
            Console.Out.WriteLine("DONE, press ENTER to exit.");
            Console.In.ReadLine();
        }

    }
}
