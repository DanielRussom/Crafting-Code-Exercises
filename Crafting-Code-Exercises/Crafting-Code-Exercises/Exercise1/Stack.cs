namespace Crafting_Code_Exercises.Exercise1
{
    internal class Stack
    {
        object HeldObject;

        internal object Pop()
        {
            return HeldObject;
        }

        internal void Push(object input)
        {
            HeldObject = input;
        }
    }
}
