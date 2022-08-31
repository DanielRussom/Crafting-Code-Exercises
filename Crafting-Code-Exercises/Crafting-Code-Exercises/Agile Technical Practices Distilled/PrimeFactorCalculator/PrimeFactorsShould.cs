using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.PrimeFactorCalculator
{
    [TestClass]
    public class PrimeFactorsShould
    {
        [TestMethod]
        [DataRow(2, new int[] { 2 })]
        [DataRow(3, new int[] { 3 })]
        [DataRow(4, new int[] { 2, 2 })]
        [DataRow(6, new int[] { 2, 3 })]
        [DataRow(9, new int[] { 3, 3 })]
        [DataRow(12, new int[] { 2, 2, 3 })]
        [DataRow(15, new int[] { 3, 5 })]
        public void Get_Prime_Numbers(int input, int[] expected)
        {
            CollectionAssert.AreEqual(expected.ToList(), PrimeFactors.GetPrimeNumbers(input));
        }
    }
}
