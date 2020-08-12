using System;
using Task1.BinaryTree.Interfaces;
using Task1.Enums;

namespace Task1.BinaryTree
{
    /// <summary>
    /// Class describes the TreeNode.
    /// </summary>
    public class TreeNode<T> : Node<T>, ITreeNode<T>, IComparable<T> where T : IComparable
    {
        /// <summary>
        /// The constructor initializes the class object.
        /// </summary>
        /// <param name="content">Сontent of the object.</param>
        /// <param name="parent">Parent.</param>
        /// <param name="tree">information about of the tree.</param>
        public TreeNode(T content, TreeNode<T> parent, BinaryTree<T> tree) : base(content, parent)
        {
            Tree = tree;
        }

        /// <summary>
        /// The property stores information about of the tree.
        /// </summary>
        public BinaryTree<T> Tree { get; set; }

        /// <summary>
        /// Method shows balance status.
        /// </summary>
        /// <returns>balance status.</returns>
        private BalanceState State
        {
            get
            {
                if (LeftHeight - RightHeight > 0)
                {
                    return BalanceState.LeftHeavy;
                }

                if (RightHeight - LeftHeight > 0)
                {
                    return BalanceState.RightHeavy;
                }

                return BalanceState.Balanced;
            }
        }

        /// <summary>
        /// The method rotates the tree to the left.
        /// </summary>
        private void LeftRotation()
        {
            Node<T> newRoot = Right;
            ReplaceRoot(newRoot);
  
            Right = newRoot.Left;
  
            newRoot.Left = this;
        }

        /// <summary>
        /// The method rotates the tree to the right.
        /// </summary>
        private void RightRotation()
        {
            Node<T> newRoot = Left;
            ReplaceRoot(newRoot);

            Left = newRoot.Right;
 
            newRoot.Right = this;
        }

        /// <summary>
        /// The method replaces the root of the tree with a new root.
        /// </summary>
        /// <param name="newRoot">New tree root.</param>
        private void ReplaceRoot(Node<T> newRoot)
        {
            if (Parent != null)
            {
                if (Parent.Left == this)
                {
                    Parent.Left = newRoot;
                }
                else if (Parent.Right == this)
                {
                    Parent.Right = newRoot;
                }
            }
            else
            {
                Tree.Root = newRoot
                    as TreeNode<T>;
            }

            newRoot.Parent = Parent;
            Parent = newRoot;
        }

        /// <summary>
        /// The method balances the tree.
        /// </summary>
        public void Balance()
        {
            switch (State)
            {
                case BalanceState.LeftHeavy:
                    if (Left != null && (RightHeight - LeftHeight) > 0)
                    {
                        LeftRotation();
                        RightRotation();
                    }
                    else
                    {
                        RightRotation();
                    }
                    break;
                case BalanceState.RightHeavy:
                    if (Right != null && (RightHeight - LeftHeight) < 0)
                    {
                        RightRotation();
                        LeftRotation();
                    }
                    else
                    {
                        LeftRotation();
                    }
                    break;
                case BalanceState.Balanced:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Method checks if the tree is balanced.
        /// </summary>
        /// <returns>True if balanced false if not</returns>
        public bool IsBalance() => LeftHeight - RightHeight == 0;

        /// <summary>
        /// Method equals two objects.
        /// </summary>
        /// <param name="obj">Equals object.</param>
        /// <returns>Returns the result of the comparison.</returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
                return false;

            var treeNode = (TreeNode<T>)obj;

            Tree.Equals(treeNode);

            return Tree.Equals(treeNode) &&
                   State == treeNode.State;
        }

        /// <summary>
        /// The method gets the hash code of the object.
        /// </summary>
        /// <returns>Returns the hash code of the object.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Tree.GetHashCode(), State);
        }

        /// <summary>
        /// The method returns information about the object in string form.
        /// </summary>
        /// <returns>Information about the object.</returns>
        public override string ToString() => Tree.ToString();
    }
}
