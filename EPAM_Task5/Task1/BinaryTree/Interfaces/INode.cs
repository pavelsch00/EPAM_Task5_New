using System;

namespace Task1.BinaryTree.Interfaces
{
    /// <summary>
    /// The interface describes the properties of the Node class.
    /// </summary>
    public interface INode<T> : IComparable<T> where T : IComparable
    {
        /// <summary>
        /// The property stores the parent node.
        /// </summary>
        public Node<T> Parent { get; set; }

        /// <summary>
        /// The property stores the left node.
        /// </summary>
        public Node<T> Left { get; set; }

        /// <summary>
        /// The property stores the right node.
        /// </summary>
        public Node<T> Right { get; set; }

        /// <summary>
        /// The property stores length of left node.
        /// </summary>
        /// <returns>Length of left node.</returns>
        public int LeftHeight { get; }

        /// <summary>
        /// The property stores length of right node.
        /// </summary>
        /// <returns>Length of right node.</returns>
        public int RightHeight { get; }
    }
}
