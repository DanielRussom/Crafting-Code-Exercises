using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.BooleanCalculations
{
    [TestClass]
    public class BooleanCalculatorShould
    {
        [TestMethod]
        [DataRow("TRUE", true)]
        [DataRow("FALSE", false)]
        [DataRow("NOT TRUE", false)]
        [DataRow("NOT FALSE", true)]
        [DataRow("TRUE AND FALSE", false)]
        [DataRow("TRUE AND TRUE", true)]
        [DataRow("FALSE AND TRUE", false)]
        [DataRow("FALSE AND FALSE", false)]
        [DataRow("TRUE OR FALSE", true)]
        [DataRow("FALSE OR TRUE", true)]
        [DataRow("FALSE OR FALSE", false)]
        [DataRow("TRUE OR TRUE", true)]
        [DataRow("NOT FALSE AND TRUE", true)]
        [DataRow("NOT TRUE AND TRUE", false)]
        [DataRow("FALSE AND NOT TRUE", false)]
        [DataRow("FALSE AND NOT FALSE", false)]
        [DataRow("NOT FALSE AND NOT TRUE", false)]
        [DataRow("NOT FALSE AND NOT FALSE", true)]
        [DataRow("NOT TRUE OR FALSE", false)]
        [DataRow("TRUE OR NOT FALSE", true)]
        [DataRow("NOT TRUE OR NOT FALSE", true)]
        [DataRow("NOT TRUE OR NOT TRUE", false)]
        [DataRow("TRUE AND TRUE AND TRUE", true)]
        [DataRow("TRUE AND TRUE AND FALSE", false)]
        [DataRow("NOT TRUE AND TRUE AND FALSE", false)]
        [DataRow("NOT TRUE AND NOT TRUE AND NOT FALSE", false)]
        [DataRow("TRUE AND TRUE AND TRUE AND FALSE", false)]
        [DataRow("TRUE OR TRUE OR TRUE", true)]
        [DataRow("FALSE OR TRUE OR TRUE", true)]
        [DataRow("FALSE OR FALSE OR FALSE", false)]
        [DataRow("FALSE OR FALSE OR TRUE", true)]
        [DataRow("FALSE OR FALSE OR FALSE OR TRUE", true)]
        [DataRow("NOT FALSE OR FALSE OR FALSE OR FALSE", true)]
        [DataRow("NOT TRUE OR NOT TRUE OR NOT TRUE OR NOT TRUE", false)]
        [DataRow("TRUE OR TRUE OR TRUE AND FALSE", true)]
        [DataRow("TRUE AND FALSE OR TRUE OR TRUE AND FALSE", true)]
        [DataRow("TRUE OR FALSE AND NOT FALSE", true)]
        [DataRow("(TRUE OR TRUE OR TRUE) AND FALSE", false)]
        [DataRow("NOT (TRUE AND TRUE)", false)]
        public void Return_expected_boolean(string input, bool expected)
        {
            var result = BooleanCalculator.GetBoolean(input);

            Assert.AreEqual(expected, result);
        }
    }
}
