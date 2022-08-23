namespace Crafting_Code_Exercises.NthFibonacci
{
    public class FibonacciNumberGenerator
    {
        public static int Generate(int positionInSequence)
        {
            if (positionInSequence > 2) return Generate(positionInSequence - 1) + Generate(positionInSequence - 2);
            return positionInSequence - 1;
        }
    }
}