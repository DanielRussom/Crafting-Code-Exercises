using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.RomanNumeralsWithTPP;

[TestClass]
public class RomanNumeralsConverterWindBackShould
{
    [TestMethod]
    [DataRow(1, "I", DisplayName = "Convert 1 to I")]
    [DataRow(2, "II", DisplayName = "Convert 2 to II")]
    [DataRow(3, "III", DisplayName = "Convert 3 to III")]
    [DataRow(5, "V", DisplayName = "Convert 5 to V")]
    [DataRow(6, "VI", DisplayName = "Convert 6 to VI")]
    [DataRow(7, "VII", DisplayName = "Convert 7 to VII")]
    [DataRow(8, "VIII", DisplayName = "Convert 8 to VIII")]
    [DataRow(10, "X", DisplayName = "Convert 10 to X")]
    [DataRow(11, "XI", DisplayName = "Convert 11 to XI")]
    [DataRow(12, "XII", DisplayName = "Convert 12 to XII")]
    [DataRow(13, "XIII", DisplayName = "Convert 13 to XIII")]
    [DataRow(15, "XV", DisplayName = "Convert 15 to XV")]
    [DataRow(16, "XVI", DisplayName = "Convert 16 to XVI")]
    [DataRow(20, "XX", DisplayName = "Convert 20 to XX")]
    public void Convert_decimal_to_RomanNumeral(int input, string expected)
    {
        var romanNumeralConverter = new RomanNumeralConverterWindBack();

        var result = romanNumeralConverter.Convert(input);

        Assert.AreEqual(expected, result);
    }
}