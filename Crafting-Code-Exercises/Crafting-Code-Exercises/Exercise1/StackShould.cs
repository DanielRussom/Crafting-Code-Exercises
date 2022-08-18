using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crafting_Code_Exercises.Exercise1
{
    [TestClass]
    public class StackShould
    {
        [TestMethod]
        public void Pop_the_last_pushed_object()
        {
            var UnderTest = new Stack();
            var input = new object();

            UnderTest.Push(input);

            var result = UnderTest.Pop();

            Assert.AreEqual(input, result);
        }
    }
}
