using System.Collections.Generic;
using Xunit;
using Task2.Humans;
using Task2.SerializationCollections;

namespace Task2.Tests.SerializationCollectionTests
{
    /// <summary>
    /// The class tests the SerializationCollection.
    /// </summary>
    public class SerializationCollectionTest
    {
        /// <summary>
        /// The method checks serialization and deserialization collection from/to binary file.
        /// </summary>
        /// <param name="areEqual">Turns the case on or off.</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void SerializationAndDeserializationCollectionBinaryFile(bool areEqual)
        {
            // arrange
            var actual = new List<Human>();

            if (areEqual)
            {
                actual = new List<Human>
                {
                    new Human("Pavel", "Belarus", "Gomel"),
                    new Human("Maxim", "Belarus", "Minsk"),
                    new Human("Misha", "Russia", "Moscow"),
                    new Human("Rita", "Belarus", "Gomel"),
                    new Human("Kolya", "Belarus", "Grodno")
                };
            }

            var serialization = new SerializationCollection<Human>();

            //act
            serialization.SaveToBinaryFile(@"..\..\..\SerializationCollectionTests\Resources\TestCollection.bin", actual);
            var expected = serialization.GetCollectionFromBinaryFile(@"..\..\..\SerializationCollectionTests\Resources\TestCollection.bin");


            //assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// The method checks serialization and deserialization from/to binary file.
        /// </summary>
        /// <param name="areEqual">Turns the case on or off.</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void SerializationAndDeserializationBinaryFile(bool areEqual)
        {
            // arrange
            var actual = new Human();

            if (areEqual)
            {
                actual = new Human("Pavel", "Belarus", "Gomel");
            }
            var serialization = new SerializationCollection<Human>();

            //act
            serialization.SaveToBinaryFile(@"..\..\..\SerializationCollectionTests\Resources\Test.bin", actual);
            var expected = serialization.GetFromBinaryFile(@"..\..\..\SerializationCollectionTests\Resources\Test.bin");

            //assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// The method checks serialization and deserialization collection from/to json file.
        /// </summary>
        /// <param name="areEqual">Turns the case on or off.</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void SerializationAndDeserializationCollectionJsonFile(bool areEqual)
        {
            // arrange
            var actual = new List<Human>();

            if (areEqual)
            {
                actual = new List<Human>
                {
                    new Human("Pavel", "Belarus", "Gomel"),
                    new Human("Maxim", "Belarus", "Minsk"),
                    new Human("Misha", "Russia", "Moscow"),
                    new Human("Rita", "Belarus", "Gomel"),
                    new Human("Kolya", "Belarus", "Grodno")
                };
            }
            var serialization = new SerializationCollection<Human>();

            //act
            serialization.SaveToJsonFile(@"..\..\..\SerializationCollectionTests\Resources\TestCollection.json", actual);
            var expected = serialization.GetCollectionFromJsonFile(@"..\..\..\SerializationCollectionTests\Resources\TestCollection.json");

            //assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// The method checks serialization and deserialization from/to json file.
        /// </summary>
        /// <param name="areEqual">Turns the case on or off.</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void SerializationAndDeserializationJsonFile(bool areEqual)
        {
            // arrange
            var actual = new Human();

            if (areEqual)
            {
                actual = new Human("Pavel", "Belarus", "Gomel");
            }
            var serialization = new SerializationCollection<Human>();

            //act
            serialization.SaveToJsonFile(@"..\..\..\SerializationCollectionTests\Resources\Test.json", actual);
            var expected = serialization.GetFromJsonFile(@"..\..\..\SerializationCollectionTests\Resources\Test.json");

            //assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// The method checks serialization and deserialization collection from/to xml file.
        /// </summary>
        /// <param name="areEqual">Turns the case on or off.</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void SerializationAndDeserializationCollectionXmlFile(bool areEqual)
        {
            // arrange
            var actual = new List<Human>();

            if (areEqual)
            {
                actual = new List<Human>
                {
                    new Human("Pavel", "Belarus", "Gomel"),
                    new Human("Maxim", "Belarus", "Minsk"),
                    new Human("Misha", "Russia", "Moscow"),
                    new Human("Rita", "Belarus", "Gomel"),
                    new Human("Kolya", "Belarus", "Grodno")
                };
            }

            var serialization = new SerializationCollection<Human>();

            //act
            serialization.SaveToXmlFile(@"..\..\..\SerializationCollectionTests\Resources\TestCollection.xml", actual);
            var expected = serialization.GetCollectionFromXmlFile(@"..\..\..\SerializationCollectionTests\Resources\TestCollection.xml");


            //assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// The method checks serialization and deserialization from/to xml file.
        /// </summary>
        /// <param name="areEqual">Turns the case on or off.</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void SerializationAndDeserializationXmlFile(bool areEqual)
        {
            // arrange
            var actual = new Human();

            if (areEqual)
            {
                actual = new Human("Pavel", "Belarus", "Gomel");
            }
            var serialization = new SerializationCollection<Human>();

            //act
            serialization.SaveToXmlFile(@"..\..\..\SerializationCollectionTests\Resources\Test.xml", actual);
            var expected = serialization.GetFromXmlFile(@"..\..\..\SerializationCollectionTests\Resources\Test.xml");

            //assert
            Assert.Equal(expected, actual);
        }
    }
}
