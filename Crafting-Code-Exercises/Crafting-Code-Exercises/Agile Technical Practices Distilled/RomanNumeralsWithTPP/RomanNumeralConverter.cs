namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.RomanNumeralsWithTPP
{
    public class RomanNumeralConverter
    {
        public string Convert(int input)
        {
            var returnValue = string.Empty;

            var reservedNumbers = new List<(int arabic, string numeral)> { (1000, "M"), (900, "CM"), (500, "D"), (400, "CD"), (100, "C"), (90, "XC"), (50, "L"), (40, "XL"), 
                (10, "X"), (9, "IX"), (5, "V"), (4, "IV"), (1, "I")};

            for (var index = 0; index < reservedNumbers.Count; index++)
            {
                while (input >= reservedNumbers[index].arabic)
                {
                    returnValue += reservedNumbers[index].numeral;
                    input -= reservedNumbers[index].arabic;
                }
            }

            return returnValue;
        }
    }
}