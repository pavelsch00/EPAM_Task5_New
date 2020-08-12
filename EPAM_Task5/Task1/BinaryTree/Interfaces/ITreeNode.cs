using System;

namespace Task1.BinaryTree.Interfaces
{
    /// <summary>
    /// The interface describes the properties and methods of the ITreeNode class.
    /// </summary>
    public interface ITreeNode<T> : IComparable<T> where T : IComparable
    {
        /// <summary>
        /// The property stores information about of the tree.
        /// </summary>
        public BinaryTree<T> Tree { get; set; }

        /// <summary>
        /// The method balances the tree.
        /// </summary>
        public void Balance();
    }
}
