using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void Push_ArgIsNull_ThrowArgNullException()
        {
            var stack = new Stack<string>();
            Assert.That(()=>stack.Push(null), Throws.ArgumentNullException);
        }
        [Test]
        public void Push_IsNotNull_AddObjectToList()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            Assert.That(stack.Count,Is.EqualTo(1));
        }
        [Test]
        public void Push_EmptyStack_AddObjectToList()
        {
            var stack = new Stack<string>();
            Assert.That(stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Pop_ArgIsInvalid_ThrowArgInvalidException()
        {
            var stack = new Stack<string>();

            Assert.That(()=>stack.Pop(), Throws.InvalidOperationException);
        }
        [Test]
        public void Pop_StackWithAFewObjects_ReturnsObjectTotheTop()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            var result = stack.Pop();

            Assert.That(result, Is.EqualTo("c"));
        }
        [Test]
        public void Pop_StackWithAFewObjects_RemovesObjectTotheTop()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            stack.Pop();

            Assert.That(stack.Count, Is.EqualTo(2));
        }
        [Test]
        public void Peek_StackWithNoObject_ThrowInvalidOperationException()
        {
            var stack = new Stack<string>();

            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);
        }
        [Test]
        public void Peek_StackWithAfewObjects_ReturnLastObject()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            var result = stack.Peek();

            Assert.That(result, Is.EqualTo("c"));
        }
        [Test]
        public void Peek_StackWithAfewObjects_CheckIfItRemovesObjectsOnTop()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            stack.Peek();

            Assert.That(stack.Count, Is.EqualTo(3));
        }
    }
}
