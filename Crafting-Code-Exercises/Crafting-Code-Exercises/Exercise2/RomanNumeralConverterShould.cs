using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crafting_Code_Exercises.Exercise2
{
    [TestClass]
    public class RomanNumeralConverterShould
    {
        [TestMethod]
        [DataRow(1, "I")]
        [DataRow(2, "II")]
        public void Convert_input_to_expected_output(int input, string expected)
        {
            var UnderTest = new RomanNumeralConverter();

            var result = UnderTest.Convert(input);

            Assert.AreEqual(expected, result);
        }
    }
}
