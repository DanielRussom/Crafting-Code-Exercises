using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crafting_Code_Exercises.NthFibonacci
{
    [TestClass]
    public class FibonacciNumberGeneratorShould
    {
        [TestMethod]
        [DataRow(1, 0, DisplayName = "Position 1 returns 0")]
        [DataRow(2, 1, DisplayName = "Position 2 returns 1")]
        [DataRow(3, 1, DisplayName = "Position 3 returns 1")]
        [DataRow(4, 2, DisplayName = "Position 4 returns 2")]
        [DataRow(5, 3, DisplayName = "Position 5 returns 3")]
        [DataRow(6, 5, DisplayName = "Position 6 returns 5")]
        [DataRow(7, 8, DisplayName = "Position 7 returns 8")]
        [DataRow(8, 13, DisplayName = "Position 8 returns 13")]
        [DataRow(10, 34, DisplayName = "Position 10 returns 34")]
        public void Generate_Fibonacci_Number(int sequencePosition, int expectedValue)
        {
            Assert.AreEqual(expectedValue, FibonacciNumberGenerator.Generate(sequencePosition));
        }
    }
}
