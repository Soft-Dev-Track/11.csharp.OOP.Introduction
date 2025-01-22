using OOP_Introduction;

namespace Test_OOP_Intro
{
    public class TestBook
    {

        private Book _book;

        [SetUp]
        public void Setup()
        {
            _book = new Book() { Author = "John Doe", Title = "How to learn C#", Pages = 100 };
        }

        [Test]
        public void TestDisplay()
        {
            // Act
            string input = "Author : John Doe - Title : How to learn C# - Page : 100";
            string result = _book.Display();

            // Assert
            Assert.That(input, Is.EqualTo(result));
        }
    }
}