namespace Crafting_Code_Exercises.Exercise1
{
    internal class Stack
    {
        readonly List<object> HeldObjects = new();

        internal void Push(object input)
        {
            HeldObjects.Add(input);
        }

        internal object Pop()
        {
            if (HeldObjectsIsEmpty())
            {
                throw new InvalidOperationException("No objects to pop.");
            }

            var lastObject = HeldObjects.Last();

            RemoveLastObject();

            return lastObject;
        }

        private bool HeldObjectsIsEmpty()
        {
            return !HeldObjects.Any();
        }

        private void RemoveLastObject()
        {
            var lastObjectIndex = HeldObjects.Count - 1;
            HeldObjects.RemoveAt(lastObjectIndex);
        }
    }
}
