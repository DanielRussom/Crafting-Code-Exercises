﻿namespace Crafting_Code_Exercises.Exercise2
{
    internal class RomanNumeralConverter
    {
        internal string Convert(int input)
        {
            var result = string.Empty;
            
            if(input >= 5)
            {
                result += "V";
                input -= 5;
            }

            if (input == 4)
            {
                result += "IV";
                input -= 4;
            }

            while (input > 0)
            {
                result += "I";
                input -= 1;
            }

            return result;
        }
    }
}
