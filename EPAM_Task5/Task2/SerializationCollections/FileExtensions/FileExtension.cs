using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Text;

namespace Task2.SerializationCollections.FileExtensions
{
    /// <summary>
    /// The class serialization any collections class.
    /// </summary>
    public class FileExtension<T>
    {
        /// <summary>
        /// The property stores start pozition for file.
        /// </summary>
        private const int _startPozition = 0;

        /// <summary>
        /// Method save collection to xml file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <param name="collection">Collection<T>.</param>
        /// <param name="actualClassVersion">Actual version class.</param>
        protected static void SaveToXmlFile(string path, ICollection<T> collection, string actualClassVersion)
        {
            byte[] buffer = Encoding.UTF8.GetBytes("Class version: " + actualClassVersion + "\n");
            try
            {
                using var fileStream = new FileStream(path, FileMode.Create);
                fileStream.Write(buffer, _startPozition, buffer.Length);
                var formatter = new XmlSerializer(typeof(List<T>));
                formatter.Serialize(fileStream, collection);
            }
            catch (Exception)
            {
                throw new ArgumentException("Failed to serialize collection.");
            }
        }

        /// <summary>
        /// Method get collection from xml file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <param name="actualClassVersion">Actual version class.</param>
        /// <returns>Collection<T>.</returns>
        protected static ICollection<T> GetCollectionFromXmlFile(string path, string actualClassVersion)
        {
            string classVersion = "Class version: " + actualClassVersion + "\n";
            byte[] buffer = Encoding.UTF8.GetBytes(classVersion);
            try
            {
                using var fileStream = new FileStream(path, FileMode.OpenOrCreate);

                var destinationArray = new byte[buffer.Length];
                fileStream.Read(destinationArray, _startPozition, destinationArray.Length);
                string message = Encoding.UTF8.GetString(destinationArray);
                if(message != classVersion)
                {
                    throw new InvalidCastException("Not actual version class. Actual class version: " + actualClassVersion);
                }

                var formatter = new XmlSerializer(typeof(List<T>));
                return (ICollection<T>)formatter.Deserialize(fileStream);
            }
            catch (Exception)
            {
                throw new ArgumentException("Failed to deserialize collection.");
            }
        }

        /// <summary>
        /// Method save collection to json file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <param name="collection">Collection<T>.</param>
        /// <param name="actualClassVersion">Actual version class.</param>
        protected static void SaveToJsonFile(string path, ICollection<T> collection, string actualClassVersion)
        {
            string classVersion = "Class version: " + actualClassVersion + "\n";
            try
            {
                using var streamWriter = new StreamWriter(path);
                streamWriter.Write(classVersion);
                streamWriter.Write(JsonConvert.SerializeObject(collection, Formatting.Indented));
            }
            catch (Exception)
            {
                throw new ArgumentException("Failed to serialize collection.");
            }
        }

        /// <summary>
        /// Method get collection from json file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <param name="actualClassVersion">Actual version class.</param>
        /// <returns>Collection<T>.</returns>
        protected static ICollection<T> GetCollectionFromJsonFile(string path, string actualClassVersion)
        {
            string classVersion = "Class version: " + actualClassVersion;
            try
            {
                using var streamReader = new StreamReader(path);
                if (streamReader.ReadLine().ToString() != classVersion)
                {
                    throw new InvalidCastException("Not actual version class. Actual class version: " + actualClassVersion);
                }

                return JsonConvert.DeserializeObject<ICollection<T>>(streamReader.ReadToEnd());
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Failed to deserialize collection.");
            } 
        }

        /// <summary>
        /// Method save item to binary file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <param name="collection">Collection<T>.</param>
        /// <param name="actualClassVersion">Actual version class.</param>
        protected static void SaveToBinaryFile(string path, ICollection<T> collection, string actualClassVersion)
        {
            byte[] buffer = Encoding.UTF8.GetBytes("Class version: " + actualClassVersion + "\n");

            try
            {
                var binaryFormatter = new BinaryFormatter();
                using var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write);
                fileStream.Write(buffer, _startPozition, buffer.Length);
                binaryFormatter.Serialize(fileStream, collection);
            }
            catch (Exception)
            {
                throw new ArgumentException("Failed to serialize collection.");
            }
        }

        /// <summary>
        /// Method get collection from binary file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <param name="actualClassVersion">Actual version class.</param>
        /// <returns>Collection<T>.</returns>
        protected static ICollection<T> GetCollectionFromBinaryFile(string path, string actualClassVersion)
        {
            string classVersion = "Class version: " + actualClassVersion + "\n";
            byte[] buffer = Encoding.UTF8.GetBytes(classVersion);

            try
            {
                var binaryFormatter = new BinaryFormatter();
                using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);

                var destinationArray = new byte[buffer.Length];
                fileStream.Read(destinationArray, _startPozition, destinationArray.Length);
                string message = Encoding.UTF8.GetString(destinationArray);
                if (message != classVersion)
                {
                    throw new InvalidCastException("Not actual version class. Actual class version: " + actualClassVersion);
                }

                return (ICollection<T>)binaryFormatter.Deserialize(fileStream);
            }
            catch (Exception)
            {
                throw new ArgumentException("Failed to serialize collection.");
            }
        }

        /// <summary>
        /// Method save collection to xml file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <param name="collection">Collection<T>.</param>
        /// <param name="actualClassVersion">Actual version class.</param>
        protected static void SaveToXmlFile(string path, T item, string actualClassVersion)
        {
            byte[] buffer = Encoding.UTF8.GetBytes("Class version: " + actualClassVersion + "\n");
            try
            {
                using var fileStream = new FileStream(path, FileMode.Create);
                fileStream.Write(buffer, _startPozition, buffer.Length);
                var formatter = new XmlSerializer(typeof(T));
                formatter.Serialize(fileStream, item);
            }
            catch (Exception)
            {
                throw new ArgumentException("Failed to serialize collection.");
            }
        }

        /// <summary>
        /// Method save collection to json file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <param name="collection">Collection<T>.</param>
        /// <param name="actualClassVersion">Actual version class.</param>
        protected static void SaveToJsonFile(string path, T item, string actualClassVersion)
        {
            string classVersion = "Class version: " + actualClassVersion + "\n";
            try
            {
                using var streamWriter = new StreamWriter(path);
                streamWriter.Write(classVersion);
                streamWriter.Write(JsonConvert.SerializeObject(item, Formatting.Indented));
            }
            catch (Exception)
            {
                throw new ArgumentException("Failed to serialize collection.");
            }
        }

        /// <summary>
        /// Method save item to binary file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <param name="collection">Collection<T>.</param>
        /// <param name="actualClassVersion">Actual version class.</param>
        protected static void SaveToBinaryFile(string path, T item, string actualClassVersion)
        {
            byte[] buffer = Encoding.UTF8.GetBytes("Class version: " + actualClassVersion + "\n");

            try
            {
                var binaryFormatter = new BinaryFormatter();
                using var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write);
                fileStream.Write(buffer, _startPozition, buffer.Length);
                binaryFormatter.Serialize(fileStream, item);
            }
            catch (Exception)
            {
                throw new ArgumentException("Failed to serialize collection.");
            }
        }

        /// <summary>
        /// Method get item from binary file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <param name="actualClassVersion">Actual version class.</param>
        /// <returns>Item<T>.</returns>
        protected static T GetFromBinaryFile(string path, string actualClassVersion)
        {
            string classVersion = "Class version: " + actualClassVersion + "\n";
            byte[] buffer = Encoding.UTF8.GetBytes(classVersion);

            try
            {
                var binaryFormatter = new BinaryFormatter();
                using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);

                var destinationArray = new byte[buffer.Length];
                fileStream.Read(destinationArray, _startPozition, destinationArray.Length);
                string message = Encoding.UTF8.GetString(destinationArray);
                if (message != classVersion)
                {
                    throw new InvalidCastException("Not actual version class. Actual class version: " + actualClassVersion);
                }

                return (T)binaryFormatter.Deserialize(fileStream);
            }
            catch (Exception)
            {
                throw new ArgumentException("Failed to serialize collection.");
            }
        }

        /// <summary>
        /// Method get item from xml file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <param name="actualClassVersion">Actual version class.</param>
        /// <returns>Item<T>.</returns>
        protected static T GetFromXmlFile(string path, string actualClassVersion)
        {
            string classVersion = "Class version: " + actualClassVersion + "\n";
            byte[] buffer = Encoding.UTF8.GetBytes(classVersion);
            try
            {
                using FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);

                var destinationArray = new byte[buffer.Length];
                fileStream.Read(destinationArray, _startPozition, destinationArray.Length);
                string message = Encoding.UTF8.GetString(destinationArray);
                if (message != classVersion)
                {
                    throw new InvalidCastException("Not actual version class. Actual class version: " + actualClassVersion);
                }

                var formatter = new XmlSerializer(typeof(T));
                return (T)formatter.Deserialize(fileStream);
            }
            catch (Exception)
            {
                throw new ArgumentException("Failed to deserialize collection.");
            }
        }

        /// <summary>
        /// Method get item from json file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <param name="actualClassVersion">Actual version class.</param>
        /// <returns>Item<T>.</returns>
        public static T GetFromJsonFile(string path, string actualClassVersion)
        {
            string classVersion = "Class version: " + actualClassVersion;
            try
            {
                using var streamReader = new StreamReader(path);
                if (streamReader.ReadLine().ToString() != classVersion)
                {
                    throw new InvalidCastException("Not actual version class. Actual class version: " + actualClassVersion);
                }

                return JsonConvert.DeserializeObject<T>(streamReader.ReadToEnd());
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Failed to deserialize collection.");
            }
        }
    }
}
