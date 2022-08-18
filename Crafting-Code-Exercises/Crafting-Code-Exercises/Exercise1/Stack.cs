namespace Crafting_Code_Exercises.Exercise1
{
    internal class Stack
    {
        readonly List<object> HeldObjects = new();

        internal object Pop()
        {
            var heldObjectCount = HeldObjects.Count;
            if(heldObjectCount < 1)
            {
                throw new InvalidOperationException();
            }

            var lastObject = HeldObjects.LastOrDefault();
            HeldObjects.RemoveAt(heldObjectCount-1);

            return lastObject;
        }

        internal void Push(object input)
        {
            HeldObjects.Add(input);
        }
    }
}
