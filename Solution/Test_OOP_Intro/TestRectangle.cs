using OOP_Introduction;


namespace Test_OOP_Intro
{
    public class TestRectangle
    {

        private RectangleEx _rectangle;

        [SetUp]
        public void Setup()
        {
            _rectangle = new RectangleEx() 
            { 
                Length = 4d,
                Width = 2d
            };
        }

        [Test]
        public void TestValidDimensions()
        {

            double l = _rectangle.Length = 2d;
            double w = _rectangle.Width = 5d;

            Assert.That(l, Is.EqualTo(2d));
            Assert.That(w, Is.EqualTo(5d));
        }

        [Test]
        public void Length_SetToNegativeValue_ThrowsArgumentOutOfRangeException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _rectangle.Length = -1);
            Assert.That(ex.ParamName, Is.EqualTo("value"), "Should throw an ArgumentOutOfRangeException for the 'value' parameter.");
            Assert.That(ex.Message, Does.StartWith("Length cannot be zero or negative."));
        }

        [Test]
        public void Width_SetToNegativeValue_ThrowsArgumentOutOfRangeException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _rectangle.Width = -1);
            Assert.That(ex.ParamName, Is.EqualTo("value"), "Should throw an ArgumentOutOfRangeException for the 'value' parameter.");
            Assert.That(ex.Message, Does.StartWith("Width cannot be zero or negative."));
        }

        [Test]
        public void Test_Area()
        {
            double result = _rectangle.CalculateArea();

            Assert.That(result, Is.EqualTo(8d));
        }
    }
}