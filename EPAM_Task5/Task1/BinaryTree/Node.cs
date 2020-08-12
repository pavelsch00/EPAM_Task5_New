using System;
using Task1.BinaryTree.Interfaces;

namespace Task1.BinaryTree
{
    /// <summary>
    /// Class describes the Node.
    /// </summary>
    public class Node<T> : INode<T>, IComparable<T> where T : IComparable
    {
        /// <summary>
        /// The field stores information about the left child.
        /// </summary>
        private Node<T> left;

        /// <summary>
        /// The field stores information about the right child.
        /// </summary>
        private Node<T> right;

        /// <summary>
        /// The constructor initializes the class object.
        /// </summary>
        /// <param name="content">Сontent of the object.</param>
        /// <param name="parent">Parent.</param>
        public Node(T content, Node<T> parent)
        {
            Content = content;
            Parent = parent;
        }

        /// <summary>
        /// The property describes the content of the object.
        /// </summary>
        public T Content { get; private set; }

        /// <summary>
        /// The property stores the parent node.
        /// </summary>
        public Node<T> Parent { get; set; }

        /// <summary>
        /// The property stores the right node.
        /// </summary>
        public Node<T> Left
        {
            get => left;

            set
            {
                left = value;

                if (left != null)
                {
                    left.Parent = this;
                }
            }
        }

        /// <summary>
        /// The property stores the right node.
        /// </summary>
        public Node<T> Right
        {
            get => right;

            set
            {
                right = value;

                if (right != null)
                {
                    right.Parent = this;
                }
            }
        }

        /// <summary>
        /// The property stores length of left node.
        /// </summary>
        public int LeftHeight { get => MaxChildHeight(Right); }

        /// <summary>
        /// The property stores length of right node.
        /// </summary>
        public int RightHeight { get => MaxChildHeight(Right); }

        /// <summary>
        /// The method finds the maximum length of the child.
        /// </summary>
        /// <param name="node">Node.</param>
        /// <returns>Returns the result of the comparison.</returns>
        public int MaxChildHeight(Node<T> node)
        {
            if (node != null)
            {
                return 1 + Math.Max(MaxChildHeight(node.Left), MaxChildHeight(node.Right));
            }

            return 0;
        }

        /// <summary>
        /// The method implements the ComparTo interface for comparing objects.
        /// </summary>
        /// <returns>Returns the result of the comparison.</returns>
        public int CompareTo(T other) => Content.CompareTo(other);

        /// <summary>
        /// Method equals two objects.
        /// </summary>
        /// <param name="obj">Equals object.</param>
        /// <returns>Returns the result of the comparison.</returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
                return false;

            Node<T> node = (Node<T>)obj;

            return Left.Content is IComparable == node.Left.Content is IComparable &&
                   Right.Content is IComparable == node.Right.Content is IComparable &&
                   LeftHeight == node.LeftHeight &&
                   RightHeight == node.RightHeight;
        }

        /// <summary>
        /// The method gets the hash code of the object.
        /// </summary>
        /// <returns>Returns the hash code of the object.</returns>
        public override int GetHashCode() => HashCode.Combine(Content, Left.Content, Right.Content, LeftHeight, RightHeight);

        /// <summary>
        /// The method returns information about the object in string form.
        /// </summary>
        /// <returns>Information about the object.</returns>
        public override string ToString() => Content.ToString();
    }
}
