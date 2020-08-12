using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using Task2.SerializationCollections.FileExtensions;
using Task2.SerializationCollections.Interfaces;
using Task2.SerializationCollections.Attributes;

namespace Task2.SerializationCollections
{
    /// <summary>
    /// The class serialization any collections class.
    /// </summary>
    public class SerializationCollection<T> : FileExtension<T>, ISerializationCollection<T> where T : ISerializable
    {
        /// <summary>
        /// The field stores for version class.
        /// </summary>
        private readonly string versionClass;

        /// <summary>
        /// The constructor initializes versionClass and class object.
        /// </summary>
        public SerializationCollection()
        {
            try
            {
                versionClass = GetClassVersion();
            }
            catch (Exception)
            {
                throw new Exception("Class version don't be find! Instal class version using VersionAttribute.");
            }
        }

        /// <summary>
        /// Method get version class<T>.
        /// </summary>
        /// <returns>Version class<T>.</returns>
        private static string GetClassVersion() => Attribute.GetCustomAttributes(typeof(T))
        .Where(item => item is VersionAttribute)
        .Select(item => item as VersionAttribute)
        .Select(item => item.classVersion).FirstOrDefault().ToString();

        /// <summary>
        /// Method get collection from binary file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <returns>Collection<T>.</returns>
        public ICollection<T> GetCollectionFromBinaryFile(string path) => GetCollectionFromBinaryFile(path, versionClass);

        /// <summary>
        /// Method save item to binary file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <param name="collection">Collection<T>.</param>
        public void SaveToBinaryFile(string path, ICollection<T> collection) => SaveToBinaryFile(path, collection, versionClass);

        /// <summary>
        /// Method get collection from json file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <returns>Collection<T>.</returns>
        public ICollection<T> GetCollectionFromJsonFile(string path) => GetCollectionFromJsonFile(path, versionClass);

        /// <summary>
        /// Method save collection to json file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <param name="collection">Collection<T>.</param>
        public void SaveToJsonFile(string path, ICollection<T> collection) => SaveToJsonFile(path, collection, versionClass);

        /// <summary>
        /// Method get collection from xml file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <returns>Collection<T>.</returns>
        public ICollection<T> GetCollectionFromXmlFile(string path) => GetCollectionFromXmlFile(path, versionClass);

        /// <summary>
        /// Method save collection to xml file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <param name="collection">Collection<T>.</param>
        public void SaveToXmlFile(string path, ICollection<T> collection) => SaveToXmlFile(path, collection, versionClass);

        /// <summary>
        /// Method get item from binary file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <returns>Item<T>.</returns>
        public T GetFromBinaryFile(string path) => GetFromBinaryFile(path, versionClass);

        /// <summary>
        /// Method save item to binary file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <param name="collection">Collection<T>.</param>
        public void SaveToBinaryFile(string path, T collection) => SaveToBinaryFile(path, collection, versionClass);

        /// <summary>
        /// Method get item from json file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <returns>Item<T>.</returns>
        public T GetFromJsonFile(string path) => GetFromJsonFile(path, versionClass);

        /// <summary>
        /// Method save collection to xml file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <param name="collection">Collection<T>.</param>
        public void SaveToXmlFile(string path, T collection) => SaveToXmlFile(path, collection, versionClass);

        /// <summary>
        /// Method save collection to json file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <param name="collection">Collection<T>.</param>
        public void SaveToJsonFile(string path, T collection) => SaveToJsonFile(path, collection, versionClass);

        /// <summary>
        /// Method get item from xml file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <returns>Item<T>.</returns>
        public T GetFromXmlFile(string path) => GetFromXmlFile(path, versionClass);
    }
}
