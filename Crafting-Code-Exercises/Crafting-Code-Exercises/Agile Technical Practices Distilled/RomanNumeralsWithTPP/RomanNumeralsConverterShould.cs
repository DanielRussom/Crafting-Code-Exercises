using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.RomanNumeralsWithTPP;

[TestClass]
public class RomanNumeralsConverterShould
{
    [TestMethod]
    [DataRow(1, "I", DisplayName = "Convert 1 to I")]
    [DataRow(2, "II", DisplayName = "Convert 2 to II")]
    [DataRow(3, "III", DisplayName = "Convert 3 to III")]
    [DataRow(4, "IV", DisplayName = "Convert 4 to IV")]
    [DataRow(5, "V", DisplayName = "Convert 5 to V")]
    [DataRow(6, "VI", DisplayName = "Convert 6 to VI")]
    [DataRow(7, "VII", DisplayName = "Convert 7 to VII")]
    [DataRow(8, "VIII", DisplayName = "Convert 8 to VIII")]
    [DataRow(9, "IX", DisplayName = "Convert 9 to IX")]
    [DataRow(10, "X", DisplayName = "Convert 10 to X")]
    [DataRow(11, "XI", DisplayName = "Convert 11 to XI")]
    [DataRow(12, "XII", DisplayName = "Convert 12 to XII")]
    [DataRow(13, "XIII", DisplayName = "Convert 13 to XIII")]
    [DataRow(14, "XIV", DisplayName = "Convert 14 to XIV")]
    [DataRow(15, "XV", DisplayName = "Convert 15 to XV")]
    [DataRow(16, "XVI", DisplayName = "Convert 16 to XVI")]
    [DataRow(17, "XVII", DisplayName = "Convert 17 to XVII")]
    [DataRow(18, "XVIII", DisplayName = "Convert 18 to XVIII")]
    [DataRow(19, "XIX", DisplayName = "Convert 19 to XIX")]
    [DataRow(20, "XX", DisplayName = "Convert 20 to XX")]
    [DataRow(21, "XXI", DisplayName = "Convert 21 to XXI")]
    [DataRow(22, "XXII", DisplayName = "Convert 22 to XXII")]
    [DataRow(23, "XXIII", DisplayName = "Convert 23 to XXIII")]
    [DataRow(24, "XXIV", DisplayName = "Convert 24 to XXIV")]
    [DataRow(25, "XXV", DisplayName = "Convert 25 to XXV")]
    [DataRow(28, "XXVIII", DisplayName = "Convert 28 to XXVIII")]
    [DataRow(29, "XXIX", DisplayName = "Convert 29 to XXIX")]
    [DataRow(30, "XXX", DisplayName = "Convert 30 to XXX")]
    [DataRow(33, "XXXIII", DisplayName = "Convert 33 to XXXIII")]
    [DataRow(34, "XXXIV", DisplayName = "Convert 34 to XXXIV")]
    [DataRow(35, "XXXV", DisplayName = "Convert 35 to XXXV")]
    [DataRow(38, "XXXVIII", DisplayName = "Convert 38 to XXXVIII")]
    [DataRow(39, "XXXIX", DisplayName = "Convert 39 to XXXIX")]
    [DataRow(40, "XL", DisplayName = "Convert 40 to XL")]
    [DataRow(44, "XLIV", DisplayName = "Convert 44 to XLIV")]
    [DataRow(48, "XLVIII", DisplayName = "Convert 48 to XLVIII")]
    [DataRow(49, "XLIX", DisplayName = "Convert 49 to XLIX")]
    [DataRow(50, "L", DisplayName = "Convert 50 to L")]
    [DataRow(56, "LVI", DisplayName = "Convert 56 to LVI")]
    [DataRow(60, "LX", DisplayName = "Convert 60 to LX")]
    [DataRow(70, "LXX", DisplayName = "Convert 70 to LXX")]
    [DataRow(80, "LXXX", DisplayName = "Convert 80 to LXXX")]
    [DataRow(90, "XC", DisplayName = "Convert 90 to XC")]
    [DataRow(99, "XCIX", DisplayName = "Convert 99 to XCIX")]
    [DataRow(100, "C", DisplayName = "Convert 100 to C")]
    [DataRow(116, "CXVI", DisplayName = "Convert 116 to CXVI")]
    [DataRow(200, "CC", DisplayName = "Convert 200 to CC")]
    [DataRow(300, "CCC", DisplayName = "Convert 300 to CCC")]
    [DataRow(400, "CD", DisplayName = "Convert 400 to CD")]
    [DataRow(500, "D", DisplayName = "Convert 500 to D")]
    [DataRow(600, "DC", DisplayName = "Convert 600 to DC")]
    [DataRow(700, "DCC", DisplayName = "Convert 700 to DCC")]
    [DataRow(800, "DCCC", DisplayName = "Convert 800 to DCCC")]
    [DataRow(900, "CM", DisplayName = "Convert 900 to CM")]
    [DataRow(1000, "M", DisplayName = "Convert 1000 to M")]
    [DataRow(4000, "MMMM", DisplayName = "Convert 4000 to MMMM")]
    [DataRow(846, "DCCCXLVI", DisplayName = "Convert 846 to DCCCXLVI")]
    [DataRow(1999, "MCMXCIX", DisplayName = "Convert 1999 to MCMXCIX")]
    [DataRow(2008, "MMVIII", DisplayName = "2008 to MMVIII")]
    public void Convert_decimal_to_RomanNumeral(int input, string expected)
    {
        var romanNumeralConverter = new RomanNumeralConverter();

        var result = romanNumeralConverter.Convert(input);

        Assert.AreEqual(expected, result);
    }
}