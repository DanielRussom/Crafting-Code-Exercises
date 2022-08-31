namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.RomanNumeralsWithTPP
{
    public class RomanNumeralConverterWindBack
    {
        // Matthew King 26/08/22 - Non windback approach took quite a long time, see if this approach is any quicker.
        public string Convert(int input)
        {
            var result = string.Empty;

            while (input >= 10)
            {
                result += "X";
                input -= 10;
            }

            if (input >= 5)
            {
                result += "V";
                input -= 5;
            }
          
            for (var index = 1; index <= input; index++)
            {
                result += "I";
            }

            return result;
        }
    }
}