using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Solab.Iso8583;
using Solab.Iso8583.Parsing;

namespace Tests {

	class Parser {

		static void PrintMessage(IsoMessage m) {
			if (m == null) {
				Console.Out.WriteLine("Mensaje nulo!");
				return;
			}
			Console.Out.WriteLine("TYPE: {0}", m.Type.ToString("x"));
			for (int i = 2; i < 128; i++) {
				if (m.HasField(i)) {
					Console.Out.WriteLine("F {0}: {1} -> '{2}'", i, m.GetObjectValue(i), m.GetField(i).ToString());
				}
			}
		}

		[STAThread]
		public static void Main(params string[] args) {
            MessageFactory mfact = ConfigParser.CreateFromFile("iso8583.xml");//.CreateDefault();
			mfact.AssignDate = true;
			mfact.TraceGenerator = new SimpleTraceGenerator(1);
			Console.Out.WriteLine("Reading file with sample messages");
			StreamReader reader = new StreamReader("parse.txt");
			string line = reader.ReadLine();
			IsoMessage m = null;
			while (line != null && line.Length > 0) {
				Console.Out.WriteLine("Parsing: {0}", line);
				m = mfact.ParseMessage(Encoding.UTF8.GetBytes(line), 12);
				PrintMessage(m);
				line = reader.ReadLine();
			}
			reader.Close();

			Console.Out.WriteLine("Creating new message");
			m = mfact.NewMessage(0x200);
			m.SetValue(41, "TEST-TERMINAL", IsoType.ALPHA, 16);
			m.SetValue(4, 501.25D, IsoType.AMOUNT, 16);
			m.SetValue(37, 12345678L, IsoType.NUMERIC, 12);
			m.SetValue(12, DateTime.Now, IsoType.TIME, 0);
			m.SetValue(13, DateTime.Now, IsoType.DATE4, 0);
			m.SetValue(15, DateTime.Now, IsoType.DATE_EXP, 0);
			PrintMessage(m);
			Console.In.ReadLine();
		}
	}

}
