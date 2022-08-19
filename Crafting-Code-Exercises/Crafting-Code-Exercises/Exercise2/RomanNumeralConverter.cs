namespace Crafting_Code_Exercises.Exercise2
{
    internal class RomanNumeralConverter
    {
        internal object Convert(int input)
        {
            if (input > 2)
            {
                return "III";
            }

            if (input > 1)
            {
                return "II";
            }

            return "I";
        }
    }
}
