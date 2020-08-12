using System;
using System.Collections.Generic;

namespace Task1.BinaryTree.Interfaces
{
    /// <summary>
    /// The interface describes the properties and method of the IBinaryTree class.
    /// </summary>
    public interface IBinaryTree<T> : IEnumerable<T> where T : IComparable
    {
        /// <summary>
        /// The method implements an iterator using recursive movement through the tree.
        /// </summary>
        /// <returns>Collection of objects<T>.</returns>
        public IEnumerator<T> TreeTraversal();

        /// <summary>
        /// The method сhecks if there is an item in the collection.
        /// </summary>
        /// <param name="collection">Collection of objects<T></param>
        /// <returns>Tru if contains or false if not</returns>
        public bool IsContains(T collection);

        /// <summary>
        /// The method adds a collection of objects to the tree.
        /// </summary>
        /// <param name="collection">Collection of objects<T></param>
        public void Add(T collection);

        /// <summary>
        /// Method removes an element from the tree.
        /// </summary>
        /// <param name="collection">Collection of objects<T></param>
        /// <returns>True if deletion happened, false if not.</returns>
        public bool Remove(T collection);

        /// <summary>
        /// The method removes all objects from the tree.
        /// </summary>
        public void Clear();

        /// <summary>
        /// Method saves objects to xml file.
        /// </summary>
        public void SaveToXmlFile(string path);

        /// <summary>
        /// Method get objects from xml file.
        /// </summary>
        public void GetFromXmlFile(string path);
    }
}
