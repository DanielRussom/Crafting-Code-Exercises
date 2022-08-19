using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crafting_Code_Exercises.Exercise2
{
    [TestClass]
    public class RomanNumeralConverterShould
    {
        [TestMethod]
        public void Convert_1_to_I()
        {
            var UnderTest = new RomanNumeralConverter();

            var result = UnderTest.Convert(1);

            Assert.AreEqual("I", result);
        }
    }
}
