using Task1.BinaryTree;
using Task1.Students;
using Xunit;

namespace Task1.Tests
{
    /// <summary>
    /// The class tests the binary tree.
    /// </summary>
    public class BinaryTreeTest
    {
        /// <summary>
        /// The method checks the addition and removal of elements in the tree.
        /// </summary>
        /// <param name="name">Student name.</param>
        /// <param name="testName">Test name.</param>
        /// <param name="testDate">Date of the test.</param>
        /// <param name="assessment">Test assessment.</param>
        [Theory]
        [InlineData("Pavel", "MMA", "18.02.2020", 10, true)]
        [InlineData("Rita", "MMA", "18.02.2020", 8, false)]
        public void AddandRemove(string name, string testName, string testDate, int assessment, bool actual)
        {
            // arrange
            var expected = new BinaryTree<Student>
            {
                new Student("Pavel", "MMA", "18.02.2020", 10),
                new Student("Maxim", "TViMS", "18.02.2020", 2),
                new Student("Rita", "MMA", "18.02.2020", 3)
            };

            //assert
            if (actual)
            {
                Assert.True(expected.Remove(new Student(name, testName, testDate, assessment)));
            }
            else
            {
                Assert.False(expected.Remove(new Student(name, testName, testDate, assessment)));
            }
        }

        /// <summary>
        /// Method checks tree balancing.
        /// </summary>
        [Fact]
        public void IsBalanceandBalance()
        {
            // arrange
            var expected = new BinaryTree<Student>
            {
                new Student("Pavel", "MMA", "18.02.2020", 10),
                new Student("Maxim", "TViMS", "18.02.2020", 2),
                new Student("Rita", "MMA", "18.02.2020", 3),
                new Student("Ostin", "MMA", "18.02.2020", 5),
                new Student("Oleg", "TViMS", "18.02.2020", 4),
                new Student("Gleb", "MMA", "18.02.2020", 8),
                new Student("Vika", "MMA", "18.02.2020", 1),
                new Student("Rita", "MMA", "18.02.2020", 3)
            };

            //act
            expected.Remove(new Student("Vika", "MMA", "18.02.2020", 1));
            expected.Remove(new Student("Oleg", "TViMS", "18.02.2020", 4));

            expected.Root.Balance();

            //assert
            Assert.True(expected.Root.IsBalance());
        }

        [Theory]
        /// <summary>
        /// The method checks whether the searched element is in the tree or not.
        /// </summary>
        /// <param name="name">Student name.</param>
        /// <param name="testName">Test name.</param>
        /// <param name="testDate">Date of the test.</param>
        /// <param name="assessment">Test assessment.</param>
        /// <param name="actual">Actual result.</param>
        [InlineData("Pavel", "MMA", "18.02.2020", 10, true)]
        [InlineData("Rita", "MMA", "18.02.2020", 8, false)]
        public void IsContains(string name, string testName, string testDate, int assessment, bool actual)
        {
            // arrange
            var collection = new BinaryTree<Student>
            {
                new Student("Pavel", "MMA", "18.02.2020", 10)
            };

            //act
            bool expected = collection.IsContains(new Student(name, testName, testDate, assessment));

            //assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// The method checks to remove all elements from the tree.
        /// </summary>
        /// <param name="areEqual">Turns the case on or off.</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Clear(bool areEqual)
        {
            // arrange
            var expected = new BinaryTree<Student>
            {
                new Student("Pavel", "MMA", "18.02.2020", 10),
                new Student("Maxim", "TViMS", "18.02.2020", 2),
                new Student("Rita", "MMA", "18.02.2020", 3)
            };
            var actual = new BinaryTree<Student>();

            //act
            if (areEqual)
            {
                expected.Clear();
            }

            //assert
            if (areEqual)
            {
                Assert.Equal(expected, actual);
            }
            else
            {
                Assert.NotEqual(expected, actual);
            }
        }

        /// <summary>
        /// The method checks for reading from a file.
        /// </summary>
        /// <param name="path">File path.</param>
        /// <param name="areEqual">Turns the case on or off.</param>
        [Theory]
        [InlineData(@"..\..\..\BinaryTreeTests\Resources\Test1.xml", true)]
        [InlineData(@"..\..\..\BinaryTreeTests\Resources\Test2.xml", false)]
        public void GetFromXmlFile(string path, bool areEqual)
        {
            // arrange
            var expected = new BinaryTree<Student>();
            var actual = new BinaryTree<Student>();
            expected.GetFromXmlFile(path);

            actual.Add(new Student("Pavel", "MMA", "18.02.2020", 10));
            actual.Add(new Student("Maxim", "TViMS", "18.02.2020", 2));
            actual.Add(new Student("Rita", "MMA", "18.02.2020", 3));
            actual.Add(new Student("Sasha", "TViMS", "18.02.2020", 5));
            actual.Add(new Student("Tolik", "MMA", "18.02.2020", 8));
            actual.Add(new Student("Michail", "TViMS", "18.02.2020", 5));
            actual.Add(new Student("Stephan", "MMA", "18.02.2020", 4));
            actual.Add(new Student("Taras", "TViMS", "18.02.2020", 1));
            actual.Add(new Student("Daniil", "MMA", "18.02.2020", 0));

            //assert
            if (areEqual)
            {
                Assert.Equal(expected, actual);
            }
            else
            {
                Assert.NotEqual(expected, actual);
            }
        }

        /// <summary>
        /// The method checks for writing to a file.
        /// </summary>
        /// <param name="path">File path.</param>
        [Theory]
        [InlineData(@"..\..\..\BinaryTreeTests\Resources\Test3.xml")]
        public void SaveToXmlFile(string path)
        {
            // arrange
            var expected = new BinaryTree<Student>();
            var actual = new BinaryTree<Student>
            {
                new Student("Pavel", "MMA", "18.02.2020", 10),
                new Student("Maxim", "TViMS", "18.02.2020", 2),
                new Student("Rita", "MMA", "18.02.2020", 3),
                new Student("Sasha", "TViMS", "18.02.2020", 5)
            };

            // act
            actual.SaveToXmlFile(path);

            expected.GetFromXmlFile(path);

            //assert

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// The method checks the equivalence of two objects.
        /// </summary>
        /// <param name="name">Student name.</param>
        /// <param name="testName">Test name.</param>
        /// <param name="testDate">Date of the test.</param>
        /// <param name="assessment">Test assessment.</param>
        /// <param name="areEqual">Turns the case on or off.</param>
        [Theory]
        [InlineData("Pavel", "MMA", "18.02.2020", 10, true)]
        [InlineData("Maxim", "MMA", "18.02.2020", 8, false)]
        public void Equal(string name, string testName, string testDate, int assessment,bool areEqual)
        {
            // arrange
            var actual = new BinaryTree<Student>
            {
                new Student("Pavel", "MMA", "18.02.2020", 10),
                new Student("Maxim", "TViMS", "18.02.2020", 2),
                new Student(name, testName, testDate, assessment)
            };

            var expected = new BinaryTree<Student>
            {
                new Student("Pavel", "MMA", "18.02.2020", 10),
                new Student("Maxim", "TViMS", "18.02.2020", 2)
            };
            //act

            if (areEqual)
            {
                expected.Add(new Student(name, testName, testDate, assessment));
            }

            //assert
            if (areEqual)
            {
                Assert.True(expected.Equals(actual));
            }else
            {
                Assert.False(expected.Equals(actual));
            }
        }

        /// <summary>
        /// The method checks the receipt of the hash code.
        /// </summary>
        /// <param name="name">Student name.</param>
        /// <param name="testName">Test name.</param>
        /// <param name="testDate">Date of the test.</param>
        /// <param name="assessment">Test assessment.</param>
        /// <param name="areEqual">Turns the case on or off.</param>
        [Theory]
        [InlineData("Pavel", "MMA", "18.02.2020", 10, true)]
        [InlineData("Maxim", "MMA", "18.02.2020", 8, false)]
        public void GetHashCodeTest(string name, string testName, string testDate, int assessment, bool areEqual)
        {
            // arrange
            var actual = new BinaryTree<Student>
            {
                new Student("Pavel", "MMA", "18.02.2020", 10),
                new Student("Maxim", "TViMS", "18.02.2020", 2),
                new Student(name, testName, testDate, assessment)
            };

            var expected = new BinaryTree<Student>
            {
                new Student("Pavel", "MMA", "18.02.2020", 10),
                new Student("Maxim", "TViMS", "18.02.2020", 2)
            };

            //act
            if (areEqual)
            {
                expected.Add(new Student(name, testName, testDate, assessment));
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
    }
}
