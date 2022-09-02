namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.BooleanCalculations
{
    internal class BooleanCalculator
    {
        internal static bool GetBoolean(string input)
        {
            if (input.Contains('('))
            {
                var isNested = false;
                var counter = 0;
                foreach(var character in input)
                {
                    if(character == '(')
                    {
                        counter++;
                    }

                    if(character == ')')
                    {
                        counter--;
                    }

                    if(counter > 1)
                    {
                        isNested = true;
                        break;
                    }
                }

                if (isNested)
                {
                    var openingIndex = input.IndexOf('(');
                    var closingIndex = input.LastIndexOf(')');

                    input = input.Substring(openingIndex+1, closingIndex- openingIndex - 1);
                }

                var splitParenthesesCommands = input.Split('(', ')').Select(x => x.Trim()).ToList();
                splitParenthesesCommands[1] = GetBoolean(splitParenthesesCommands[1]).ToString().ToUpper();

                if(splitParenthesesCommands.Count > 3)
                {
                    splitParenthesesCommands[3] = GetBoolean(splitParenthesesCommands[3]).ToString().ToUpper();
                }
                
                input = string.Join(' ', splitParenthesesCommands);
            }

            input = input.Trim();

            if (input == "NOT TRUE")
            {
                return false;
            }

            if (input == "NOT FALSE")
            {
                return true;
            }

            var splitOrCommands = input.Split(" OR ");
            if (splitOrCommands.Length > 1)
            {
                var result = false;
                foreach (var operand in splitOrCommands)
                {
                    result |= GetBoolean(operand);
                }

                return result;
            }

            var splitAndCommands = input.Split(" AND ");
            if (splitAndCommands.Length > 1)
            {
                var result = true;
                foreach (var operand in splitAndCommands)
                {
                    result &= GetBoolean(operand);
                }

                return result;
            }

            return Boolean.Parse(input);
        }
    }
}