using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Task2.SerializationCollections.Interfaces
{
    /// <summary>
    /// The class describes the SerializationCollection class.
    /// </summary>
    interface ISerializationCollection<T> where T : ISerializable
    {
        /// <summary>
        /// Method get collection from binary file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <returns>Collection<T>.</returns>
        public ICollection<T> GetCollectionFromBinaryFile(string path);

        /// <summary>
        /// Method get collection from json file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <returns>Collection<T>.</returns>
        public ICollection<T> GetCollectionFromJsonFile(string path);

        /// <summary>
        /// Method get collection from xml file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <returns>Collection<T>.</returns>
        public ICollection<T> GetCollectionFromXmlFile(string path);

        /// <summary>
        /// Method save collection to xml file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <param name="collection">Collection<T>.</param>
        public void SaveToXmlFile(string path, ICollection<T> collection);

        /// <summary>
        /// Method get item from xml file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <returns>Item<T>.</returns>
        public T GetFromXmlFile(string path);

        /// <summary>
        /// Method save collection to json file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <param name="collection">Collection<T>.</param>
        public void SaveToJsonFile(string path, ICollection<T> collection);

        /// <summary>
        /// Method get item from json file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <returns>Item<T>.</returns>
        public T GetFromJsonFile(string path);

        /// <summary>
        /// Method save item to binary file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <param name="collection">Collection<T>.</param>
        public void SaveToBinaryFile(string path, ICollection<T> collection);

        /// <summary>
        /// Method get item from binary file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <returns>Item<T>.</returns>
        public T GetFromBinaryFile(string path);
    }
}
