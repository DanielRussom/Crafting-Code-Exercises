using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crafting_Code_Exercises.Exercise2
{
    [TestClass]
    public class RomanNumeralConverterShould
    {
        [TestMethod]
        [DataRow (1, "I", DisplayName = "1 to I")]
        [DataRow (2, "II", DisplayName = "2 to II")]
        [DataRow (3, "III", DisplayName = "3 to III")]
        [DataRow(4, "IV", DisplayName = "4 to IV")]
        [DataRow(5, "V", DisplayName = "5 to V")]
        [DataRow(6, "VI", DisplayName = "6 to VI")]
        [DataRow(7, "VII", DisplayName = "7 to VII")]
        [DataRow(8, "VIII", DisplayName = "8 to VIII")]
        [DataRow(9, "IX", DisplayName = "9 to IX")]
        [DataRow(10, "X", DisplayName = "10 to X")]
        [DataRow(11, "XI", DisplayName = "11 to XI")]
        [DataRow(12, "XII", DisplayName = "12 to XII")]
        [DataRow(13, "XIII", DisplayName = "13 to XIII")]
        [DataRow(14, "XIV", DisplayName = "14 to XIV")]
        public void Convert(int input, string expected)
        {
            Assert.AreEqual(expected, RomanNumeralConverter.Convert(input));
        }
    }
}
