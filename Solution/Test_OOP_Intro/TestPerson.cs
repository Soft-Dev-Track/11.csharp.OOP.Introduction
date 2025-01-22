using OOP_Introduction;

namespace Test_OOP_Intro
{
    public class TestPerson
    {
        private Person _adultPerson;
        private Person _childPerson;

        [SetUp]
        public void Setup()
        {
            _adultPerson = new Person("John", 23);
            _childPerson = new Person("Hector", 12);
        }

        [Test]
        public void Display_ReturnsCorrectDescriptionForAdult()
        {
            // Act
            string expected = "John is 23 years old : Adult";
            string actual = _adultPerson.Display();

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void IsAdult_ReturnsTrueForAdults()
        {
            // Act
            bool isAdult = _adultPerson.IsAdult();

            // Assert
            Assert.That(isAdult, Is.True);
        }

        [Test]
        public void IsAdult_ReturnsFalseForChildren()
        {
            // Act
            bool isAdult = _childPerson.IsAdult();

            // Assert
            Assert.That(isAdult, Is.False);
        }
    }
}