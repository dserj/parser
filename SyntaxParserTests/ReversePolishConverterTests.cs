using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SyntaxParserTests
{
    using PolishConverter;
    using PolishEvaluator;

    [TestClass]
    public class ReversePolishConverterTests
    {
        [TestMethod]
        public void TestConverter()
        {
            var converter = new ReversePolishConverter("5+2*3");
            var result = converter.Convert();

            Assert.AreEqual(result, "523*+");
        }

        [TestMethod]
        public void TetsEvaluator()
        {
            var evaluator = new PolishEvaluator("523*+");
            var result = evaluator.Evaluate();

            Assert.AreEqual(result, 11, string.Format("Expected 11, but got {0}", result));
        }

        [TestMethod]
        public void TestCalculator()
        {
            var converter = new ReversePolishConverter("5+2*3");
            var evaluator = new PolishEvaluator(converter.Convert());
            var result = evaluator.Evaluate();

            Assert.AreEqual(result, 11, string.Format("Expected 11, but got {0}", result));
        }
    }
}
