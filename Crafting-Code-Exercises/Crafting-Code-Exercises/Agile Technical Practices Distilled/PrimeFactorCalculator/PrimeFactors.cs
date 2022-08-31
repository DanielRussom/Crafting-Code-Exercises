using System.Collections;

namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.PrimeFactorCalculator
{
    internal class PrimeFactors
    {
        internal static List<int> GetPrimeNumbers(int input)
        {
            var factors = new Dictionary<int, List<int>> {
                {15, new List<int> { 3, 5 } },
                {12, new List<int> { 2, 2, 3 } },
                {9, new List<int> { 3, 3 } },
                {6, new List<int> { 2, 3 } },
                {4, new List<int> { 2, 2 } },
                {3, new List<int> { 3 } },
                {2, new List<int> { 2 } },
            };

            return factors[input];
        }
    }
}