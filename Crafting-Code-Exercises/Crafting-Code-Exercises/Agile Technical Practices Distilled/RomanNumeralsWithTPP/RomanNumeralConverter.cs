namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.RomanNumeralsWithTPP
{
    public class RomanNumeralConverter
    {
        public string Convert(int input)
        {
            var numerals = new List<string> { "I", "II", "III", "IV", "V" };
            return numerals[input - 1];
        }
    }
}