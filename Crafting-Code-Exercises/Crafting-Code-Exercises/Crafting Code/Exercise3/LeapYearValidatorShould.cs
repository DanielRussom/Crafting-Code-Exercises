using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crafting_Code_Exercises.Exercise3
{
    [TestClass]
    public class LeapYearValidatorShould
    {
        [TestMethod]
        [DataRow(1999, DisplayName = "1999")]
        [DataRow(1998, DisplayName = "1998")]
        [DataRow(1997, DisplayName = "1997")]
        [DataRow(1700, DisplayName = "1700")]
        [DataRow(1800, DisplayName = "1800")]
        [DataRow(1900, DisplayName = "1900")]
        public void SayYearToTestIsNotALeapYear(int yearToTest)
        {
            Assert.IsFalse(LeapYearValidator.Validate(yearToTest));
        }
        
        [TestMethod]
        [DataRow(1996, DisplayName = "1996")]
        [DataRow(1992, DisplayName = "1992")]
        [DataRow(1988, DisplayName = "1988")]
        [DataRow(1600, DisplayName = "1600")]
        [DataRow(2000, DisplayName = "2000")]
        [DataRow(2400, DisplayName = "2400")]
        public void SayYearToTestIsALeapYear(int yearToTest)
        {
            Assert.IsTrue(LeapYearValidator.Validate(yearToTest));
        }
    }
}
