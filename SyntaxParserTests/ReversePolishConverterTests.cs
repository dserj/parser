using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SyntaxParserTests
{
    using PolishConverter;

    [TestClass]
    public class ReversePolishConverterTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var converter = new ReversePolishConverter("5+2*3");
            var result = converter.Convert();

            Assert.AreEqual(result, "523*+");
        }
    }
}
