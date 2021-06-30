using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberSeries;

namespace CodeTest.Tests
{
    [TestClass]
    public class NumberServiceTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            // arrange
            string inputSeries = "6 1 5 9 2";

            // act
            var numberSeries = new NumberService();
            var result = numberSeries.GetBiggestSeries(inputSeries);

            // Assert
            Assert.AreEqual("1 5 9", result);

        }
    }
}
