namespace Crafting_Code_Exercises.Exercise2
{
    public class RomanNumeralConverter
    {
        public enum RomanNumerals
        {
            M = 1000,  CM = 900,  D = 500,  CD = 400,  C = 100,  XC = 90,  L = 50,  XL = 40,  X = 10,  IX = 9,  V = 5,
            IV = 4,  I = 1
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