using System.Linq;
using static Crafting_Code_Exercises.Exercise2.RomanNumeralConverter;

namespace Crafting_Code_Exercises.Exercise2
{
    public class RomanNumeralConverter
    {
        public enum RomanNumerals
        {
            X = 10,
            IX = 9,
            V = 5,
            IV = 4,
            I = 1
        }

        public static string Convert(int input)
        {
            var result = string.Empty;

            var numeralValues = Enum.GetValues<RomanNumerals>().ToList().OrderByDescending(x => (int)x);

            foreach (var numeral in numeralValues)
            {
                while (input >= (int)numeral)
                {
                    result += numeral.ToString();
                    input -= (int)numeral;
                }
            }

            return result;
        }
    }
}