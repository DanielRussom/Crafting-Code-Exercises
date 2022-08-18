using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crafting_Code_Exercises.Exercise1
{
    [TestClass]
    public class StackShould
    {
        private Stack UnderTest;

        public StackShould()
        {
            UnderTest = new Stack();
        }

        [TestMethod]
        public void Pop_the_last_pushed_object()
        {
            var input = new object();

            UnderTest.Push(input);

            var result = UnderTest.Pop();

            Assert.AreEqual(input, result);
        }

        [TestMethod]
        public void Pop_multiples_objects_in_order()
        {
            var firstInput = new object();
            var secondInput = new object();

            UnderTest.Push(firstInput);
            UnderTest.Push(secondInput);

            var firstResult = UnderTest.Pop();
            var secondResult = UnderTest.Pop();

            Assert.AreEqual(firstInput, secondResult);
            Assert.AreEqual(secondInput, firstResult);
        }

        [TestMethod]
        public void Throw_exeption_when_popping_empty_stack()
        {
            Assert.ThrowsException<InvalidOperationException>(() => UnderTest.Pop());
        }
    }
}
