using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Task1.BinaryTree.FileExtensions
{
    /// <summary>
    /// Class save/get date for xml file.
    /// </summary>
    public static class XmlFileExtension<T>
    {
        /// <summary>
        /// Method saves objects to xml file.
        /// </summary>
        /// <param name="path">Path to file<T>.</param>
        /// <param name="collection">Collection of objects<T>.</param>
        public static void SaveToFile(string path, List<T> collection)
        {
            try
            {
                using var fs = new FileStream(path, FileMode.OpenOrCreate);
                var formatter = new XmlSerializer(typeof(List<T>));
                formatter.Serialize(fs, collection);
            }
            catch (Exception)
            {
                throw new ArgumentException("Failed to serialize collection.");
            }
        }

        /// <summary>
        /// Method get objects from xml file.
        /// </summary>
        /// <param name="path">Path to file<T>.</param>
        /// <returns>Collection<T>.</returns>
        public static List<T> GetFromFile(string path )
        {
            using FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            var formatter = new XmlSerializer(typeof(List<T>));
            return (List<T>)formatter.Deserialize(fs);
        }
    }
}
