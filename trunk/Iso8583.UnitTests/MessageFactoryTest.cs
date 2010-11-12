using Solab.Iso8583;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solab.Iso8583.Parsing;
using System.Text;
using System;
namespace Iso8583.UnitTests
{
    
    
    /// <summary>
    ///This is a test class for MessageFactoryTest and is intended
    ///to contain all MessageFactoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MessageFactoryTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for NewMessage
        ///</summary>
        [TestMethod(), DeploymentItem("iso8583.xml")]
        public void NewMessageTest()
        {
            MessageFactory mfact = ConfigParser.CreateFromFile("iso8583.xml");//.CreateDefault();
            Assert.IsNotNull(mfact);

            mfact.AssignDate = true;
            mfact.TraceGenerator = new SimpleTraceGenerator(1);

            DateTime dt = DateTime.Now;
            IsoMessage m = mfact.NewMessage(0x200);
            m.SetValue(41, "TEST-TERMINAL", IsoType.ALPHA, 16);
            m.SetValue(4, 501.25D, IsoType.AMOUNT, 16);
            m.SetValue(37, 12345678L, IsoType.NUMERIC, 12);
            m.SetValue(12, dt, IsoType.TIME, 0);
            m.SetValue(13, dt, IsoType.DATE4, 0);
            m.SetValue(15, dt, IsoType.DATE_EXP, 0);

            Assert.IsTrue(m.Type==0x200);
            Assert.IsTrue(m.IsoHeader == "ISO015000050");
            Assert.IsTrue(m.GetField(41).ToString() == "TEST-TERMINAL   ");
            Assert.IsTrue(m.GetField(4).ToString() == "000000050125");
            Assert.IsTrue(m.GetField(37).ToString() == "000012345678");
            Assert.IsTrue(m.GetField(12).ToString() == dt.ToString("HHmmss"));
            Assert.IsTrue(m.GetField(13).ToString() == dt.ToString("MMdd"));
            Assert.IsTrue(m.GetField(15).ToString() == dt.ToString("yyMM"));
        }

        /// <summary>
        ///A test for ParseMessage
        ///</summary>
        [TestMethod(), DeploymentItem("iso8583.xml")]
        public void ParseMessageTest()
        {
            MessageFactory mfact = ConfigParser.CreateFromFile("iso8583.xml");//.CreateDefault();
            Assert.IsNotNull(mfact);

            mfact.AssignDate = true;
            mfact.TraceGenerator = new SimpleTraceGenerator(1);

            StringBuilder sb = new StringBuilder("ISO025000055");//Header
            sb.Append("0210");//Type
            sb.Append("B23A80012EA080180000000014000004");//BITMAP
            //Use Extend BITMAP, 3,4,7,11,12,13,15,17,32
            //35,37,38,39,41,43,49,60,61
            //100,102,126
            sb.Append("65000");//3
            sb.Append("0000000003000");//4
            sb.Append("0428130547");//7
            sb.Append("468771");//11
            sb.Append("125946");//12
            sb.Append("0428");//13
            sb.Append("0428");//15
            sb.Append("0811");//17
            sb.Append("03123");//32
            sb.Append("173766123456123456=");//35
            sb.Append("001234425791");//37
            sb.Append("144723");//38
            sb.Append("00");//39
            sb.Append("614209027600TEST");//41
            sb.Append("SOLAB                 TEST-3       DF MX");//43
            sb.Append("484");//49
            sb.Append("012B123PRO1+000");//60
            sb.Append("013        0000P");
            sb.Append("03123");//100
            sb.Append("04ABCD");//102
            sb.Append("040ABCD8123477547                          ");//126

            IsoMessage m = mfact.ParseMessage(Encoding.UTF8.GetBytes(sb.ToString()), 12);
            Assert.IsTrue(m.IsoHeader == "ISO025000055");
            Assert.IsTrue(m.Type==0x210);
            Assert.IsTrue(m.GetField(3).ToString() == "650000");
            Assert.IsTrue(m.GetField(4).ToString() == "000000003000");
            Assert.IsTrue(m.GetField(7).ToString() == "0428130547");
            Assert.IsTrue(m.GetField(11).ToString() == "468771");
            Assert.IsTrue(m.GetField(12).ToString() == "125946");
            Assert.IsTrue(m.GetField(13).ToString() == "0428");
            Assert.IsTrue(m.GetField(15).ToString() == "0428");
            Assert.IsTrue(m.GetField(17).ToString() == "0811");
            Assert.IsTrue(m.GetField(32).ToString() == "123");
            Assert.IsTrue(m.GetField(35).ToString() == "3766123456123456=");
            Assert.IsTrue(m.GetField(37).ToString() == "001234425791");
            Assert.IsTrue(m.GetField(38).ToString() == "144723");
            Assert.IsTrue(m.GetField(39).ToString() == "00");
            Assert.IsTrue(m.GetField(41).ToString() == "614209027600TEST");
            //Assert.IsTrue(m.GetField(43).ToString() == "");
            Assert.IsTrue(m.GetField(49).ToString() == "484");
            Assert.IsTrue(m.GetField(60).ToString() == "B123PRO1+000");
            //Assert.IsTrue(m.GetField(61).ToString() == "");
            Assert.IsTrue(m.GetField(100).ToString() == "123");
            Assert.IsTrue(m.GetField(102).ToString() == "ABCD");
            Assert.IsTrue(m.GetField(126).ToString() == "ABCD8123477547                          ");

            sb.Remove(0,sb.Length);
            sb.Append("ISO0250000550210B23A80012EA080180000000014000004650000000000003000042813060446877413010304280428070903123173766123456123456=00123442579414474500637107053300TESTSOLAB                 TEST-3       DF MX484012B123PRO1+000013        0000P0312304ABCD040ABCD6421234099                          ");
            m = mfact.ParseMessage(Encoding.UTF8.GetBytes(sb.ToString()), 12);
            Assert.IsTrue(m.Type == 0x210);
            Assert.IsTrue(m.IsoHeader == "ISO025000055");
            Assert.IsTrue(m.GetField(3).ToString() == "650000");
            Assert.IsTrue(m.GetField(4).ToString() == "000000003000");
            Assert.IsTrue(m.GetField(7).ToString() == "0428130604");
            Assert.IsTrue(m.GetField(11).ToString() == "468774");
            Assert.IsTrue(m.GetField(12).ToString() == "130103");
            Assert.IsTrue(m.GetField(13).ToString() == "0428");
            Assert.IsTrue(m.GetField(15).ToString() == "0428");
            Assert.IsTrue(m.GetField(17).ToString() == "0709");
            Assert.IsTrue(m.GetField(32).ToString() == "123");
            Assert.IsTrue(m.GetField(35).ToString() == "3766123456123456=");
            Assert.IsTrue(m.GetField(37).ToString() == "001234425794");
            Assert.IsTrue(m.GetField(38).ToString() == "144745");
            Assert.IsTrue(m.GetField(39).ToString() == "00");
            Assert.IsTrue(m.GetField(41).ToString() == "637107053300TEST");
            //Assert.IsTrue(m.GetField(43).ToString() == "");
            Assert.IsTrue(m.GetField(49).ToString() == "484");
            Assert.IsTrue(m.GetField(60).ToString() == "B123PRO1+000");
            //Assert.IsTrue(m.GetField(61).ToString() == "");
            Assert.IsTrue(m.GetField(100).ToString() == "123");
            Assert.IsTrue(m.GetField(102).ToString() == "ABCD");
            Assert.IsTrue(m.GetField(126).ToString() == "ABCD6421234099                          ");
        }
    }
}
