using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arboles_binarios
{
    public class Node <T>
    {
        public T Data { get; set; }
        public Node <T> RightNode { get; set; }
        public Node<T> ParentNode { get; set; }
        public Node<T> LeftNode { get; set; }
        public int Height { get; }

        public Tree<T> tree { get; private set; }

        public bool IsLeaf()
        {
            if (LeftNode == null && RightNode == null)
            {
                return true;
            }
            return false;
        }
        public bool HasChildren() => !IsLeaf();
        
        Node <T> GetSibling()
        {
            if(ParentNode == null )
            {
                throw new InvalidOperationException("This node has no parent");
            }
            Node <T> left = ParentNode.LeftNode;
            Node <T> right = ParentNode.RightNode;
            if (left == this)
            {
                return right;
            }
            else
            {
                return left;
            }
        }
        public Node(T data, Node<T> parent, Tree<T> arbol)
        {
            Data = data;
            ParentNode = parent;
            RightNode = null;
            LeftNode = null;
            tree = arbol;
            if(parent != null)
            {
                Height = ParentNode.Height + 1;
            }
            else
            {
                Height = 0;
            }
        }
    }
}
