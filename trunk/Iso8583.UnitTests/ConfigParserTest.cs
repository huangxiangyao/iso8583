using Solab.Iso8583.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solab.Iso8583;

namespace Iso8583.UnitTests
{
    
    
    /// <summary>
    ///This is a test class for ConfigParserTest and is intended
    ///to contain all ConfigParserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ConfigParserTest
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
        ///A test for CreateFromFile
        ///</summary>
        [TestMethod(), DeploymentItem("iso8583.xml")]
        public void CreateFromFileTest()
        {
            MessageFactory mfact = ConfigParser.CreateFromFile("iso8583.xml");//.CreateDefault();
            Assert.IsNotNull(mfact);

            mfact.AssignDate = true;
            mfact.TraceGenerator = new SimpleTraceGenerator(1);

            Assert.IsTrue(mfact.GetIsoHeader(0x200) == "ISO015000050");
            Assert.IsTrue(mfact.GetIsoHeader(0x210) == "ISO015000055");
            Assert.IsTrue(mfact.GetIsoHeader(0x400) == "ISO015000050");
            Assert.IsTrue(mfact.GetIsoHeader(0x410) == "ISO015000055");
            Assert.IsTrue(mfact.GetIsoHeader(0x800) == "ISO015000015");
            Assert.IsTrue(mfact.GetIsoHeader(0x810) == "ISO015000015");
        }
    }
}
