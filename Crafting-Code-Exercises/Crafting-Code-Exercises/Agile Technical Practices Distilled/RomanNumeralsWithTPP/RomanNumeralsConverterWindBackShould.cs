using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.RomanNumeralsWithTPP;

[TestClass]
public class RomanNumeralsConverterWindBackShould
{
    [TestMethod]
    [DataRow(1, "I", DisplayName = "Convert 1 to I")]
    [DataRow(2, "II", DisplayName = "Convert 2 to II")]
    [DataRow(3, "III", DisplayName = "Convert 3 to III")]
    public void Convert_decimal_to_RomanNumeral(int input, string expected)
    {
        var romanNumeralConverter = new RomanNumeralConverter();

        var result = romanNumeralConverter.Convert(input);

        Assert.AreEqual(expected, result);
    }
}