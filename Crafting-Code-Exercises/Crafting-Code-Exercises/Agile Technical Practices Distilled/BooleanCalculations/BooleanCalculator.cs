namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.BooleanCalculations
{
    internal class BooleanCalculator
    {
        internal static bool GetBoolean(string input)
        {
            if (input == "NOT TRUE")
            {
                return false;
            }

            if (input == "NOT FALSE")
            {
                return true;
            }

            var splitOrInput = input.Split(" OR ");
            if (splitOrInput.Length > 1)
            {
                var result = false;
                foreach (var operand in splitOrInput)
                {
                    result |= GetBoolean(operand);
                }

                return result;
            }

            var splitAndInput = input.Split(" AND ");
            if (splitAndInput.Length > 1)
            {
                var result = true;
                foreach (var operand in splitAndInput)
                {
                    result &= GetBoolean(operand);
                }

                return result;
            }

            return Boolean.Parse(input);
        }
    }
}