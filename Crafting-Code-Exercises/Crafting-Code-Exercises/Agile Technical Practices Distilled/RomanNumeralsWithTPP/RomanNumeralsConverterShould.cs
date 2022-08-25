using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.RomanNumeralsWithTPP;

[TestClass]
public class RomanNumeralsConverterShould
{
    [TestMethod]
    public void Convert_1_to_I()
    {
        var romanNumeralConverter = new RomanNumeralConverter();

        var result = romanNumeralConverter.Convert(1);

        Assert.AreEqual("I", result);
    }

    [TestMethod]
    public void Convert_2_to_II()
    {
        var romanNumeralConverter = new RomanNumeralConverter();

        var result = romanNumeralConverter.Convert(2);

        Assert.AreEqual("II", result);
    }
}