namespace Crafting_Code_Exercises.Exercise2
{
    internal class RomanNumeralConverter
    {
        internal string Convert(int input)
        {
            if(input == 5)
            {
                return "V";
            }
            
            var result = string.Empty;

            for(int i = 0; i < input; i++)
            {
                result += "I";
            }

            return result;
        }
    }
}
