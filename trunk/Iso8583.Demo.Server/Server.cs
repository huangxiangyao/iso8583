using System;
using Solab.Iso8583;
using Solab.Iso8583.Parsing;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace Tests {

    class Server {

        private static MessageFactory mfact;
        private TcpClient socket;

        public Server(TcpClient s) {
            socket = s;
        }

        public void Listen() {
            int count = 0;
            byte[] lenbuf = new byte[2];
            try {
                //For high volume apps you will be better off only reading the stream in this thread
                //and then using another thread to parse the buffers and process the requests
                //Otherwise the network buffer might fill up and you can miss a request.
                while (socket != null && socket.Connected && Thread.CurrentThread.IsAlive) {
                    if (socket.GetStream().Read(lenbuf, 0, 2) == 2) {
                        int size = ((lenbuf[0] & 0xff) << 8) | (lenbuf[1] & 0xff);
                        byte[] buf = new byte[size];
                        //We're not expecting ETX in this case
                        socket.GetStream().Read(buf, 0, buf.Length);
                        count++;
                        //Set a job to parse the message and respond
                        //Delay it a bit to pretend we're doing something important
                        Processor p = new Processor(buf, socket, mfact);
                        new Thread(new ThreadStart(p.Respond)).Start();
                    }
                }
            } catch (IOException ex) {
                Console.Out.WriteLine("Exception occurred... {0}", ex);
            }
            Console.Out.WriteLine("Exiting after reading {0} requests", count);
            try {
                socket.Close();
            } catch (IOException) { }
        }

        [STAThread]
        public static void Main(string[] args) {
            mfact = ConfigParser.CreateFromFile("iso8583.xml");
            TcpListener server = new TcpListener(9999);
            while (true) {
                TcpClient client = server.AcceptTcpClient();
                Server sproc = new Server(client);
                new Thread(new ThreadStart(sproc.Listen)).Start();
            }
        }

    }


}
