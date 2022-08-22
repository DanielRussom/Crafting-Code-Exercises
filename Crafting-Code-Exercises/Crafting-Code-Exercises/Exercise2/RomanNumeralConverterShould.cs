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
        [DataRow(15, "XV", DisplayName = "15 to XV")]
        [DataRow(40, "XL", DisplayName = "40 to XL")]
        [DataRow(50, "L", DisplayName = "50 to L")]
        [DataRow(57, "LVII", DisplayName = "57 to LVII")]
        [DataRow(90, "XC", DisplayName = "90 to XC")]
        [DataRow(100, "C", DisplayName = "100 to C")]
        [DataRow(400, "CD", DisplayName = "400 to CD")]
        [DataRow(500, "D", DisplayName = "500 to D")]
        [DataRow(900, "CM", DisplayName = "900 to CM")]
        [DataRow(1000, "M", DisplayName = "1000 to M")]
        public void Convert(int input, string expected)
        {
            Assert.AreEqual(expected, RomanNumeralConverter.Convert(input));
        }

        [TestMethod]
        [DataRow(4, "IV", DisplayName = "4 to IV")]
        [DataRow(9, "IX", DisplayName = "9 to IX")]
        [DataRow(29, "XXIX", DisplayName = "29 to XXIX")]
        [DataRow(80, "LXXX", DisplayName = "80 to LXXX")]
        [DataRow(294, "CCXCIV", DisplayName = "294 to CCXCIV")]
        [DataRow(2019, "MMXIX", DisplayName = "2019 to MMXIX")]
        public void PassExampleTests(int input, string expected)
        {
            Assert.AreEqual(expected, RomanNumeralConverter.Convert(input));
        }
    }
}
