using Task2.Humans;
using Xunit;

namespace Task2.Tests.HumanTests
{
    /// <summary>
    /// The class tests the human.
    /// </summary>
    public class HumanTest
    {
        /// <summary>
        /// The method checks the equivalence of two objects.
        /// </summary>
        /// <param name="name">Student name.</param>
        /// <param name="city">City name.</param>
        /// <param name="country">Country of the test.</param>
        /// <param name="areEqual">Turns the case on or off.</param>
        [Theory]
        [InlineData("Pavel", "Belarus", "Gomel", true)]
        [InlineData("Misha", "Russia", "Moscow", false)]
        public void Equal(string name, string city, string country, bool areEqual)
        {
            // arrange
            var actual = new Human(name, city, country);
            var expected = new Human();

            //act
            if (areEqual)
            {
                expected = new Human("Pavel", "Belarus", "Gomel");
            }

            //assert
            if (areEqual)
            {
                Assert.True(expected.Equals(actual));
            }
            else
            {
                Assert.False(expected.Equals(actual));
            }
        }

        /// <summary>
        /// The method checks the receipt of the hash code.
        /// </summary>
        /// <param name="name">Student name.</param>
        /// <param name="city">City name.</param>
        /// <param name="country">Country of the test.</param>
        /// <param name="areEqual">Turns the case on or off.</param>
        [Theory]
        [InlineData("Pavel", "Belarus", "Gomel", true)]
        [InlineData("Misha", "Russia", "Moscow", false)]
        public void GetHeshCode(string name, string city, string country, bool areEqual)
        {
            // arrange
            var actual = new Human(name, city, country);
            var expected = new Human();

            //act
            if (areEqual)
            {
                expected = new Human("Pavel", "Belarus", "Gomel");
            }

            //assert
            if (areEqual)
            {
                Assert.Equal(expected.GetHashCode(), actual.GetHashCode());
            }
            else
            {
                Assert.NotEqual(expected.GetHashCode(), actual.GetHashCode());
            }
        }

        /// <summary>
        /// The method checks the ToString method.
        /// </summary>
        /// <param name="name">Student name.</param>
        /// <param name="city">City name.</param>
        /// <param name="country">Country of the test.</param>
        /// <param name="areEqual">Turns the case on or off.</param>
        [Theory]
        [InlineData("Pavel", "Belarus", "Gomel", true)]
        [InlineData("Misha", "Russia", "Moscow", false)]
        public void ToStringTest(string name, string city, string country, bool areEqual)
        {
            // arrange
            var actual = new Human(name, city, country);
            var expected = new Human();

            //act
            if (areEqual)
            {
                expected = new Human("Pavel", "Belarus", "Gomel");
            }

            //assert
            if (areEqual)
            {
                Assert.Equal(expected.ToString(), actual.ToString());
            }
            else
            {
                Assert.NotEqual(expected.ToString(), actual.ToString());
            }
        }
    }
}
