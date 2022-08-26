namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.RomanNumeralsWithTPP
{
    public class RomanNumeralConverterWindBack
    {
        // Matthew King 26/08/22 - Non windback approach took quite a long time, see if this approach is any quicker.
        public string Convert(int input)
        {
            var numerals = new List<string> { "I", "II", "III", };
            return numerals[input - 1];
        }
    }
}