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

        public bool IsLeaf()
        {
            if (LeftNode == null && RightNode == null)
            {
                return true;
            }
            return false;
        }
        public bool HasChildren()
        {
            if (LeftNode == null || RightNode == null)
            {
                return true;
            }
            return false;
        }
        Node <T> GetSibling()
        {
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

        public Node(T data)
        {
            Data = data;
            ParentNode = null;
            RightNode = null;
            LeftNode = null;
        }
    }
}
