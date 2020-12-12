using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arboles_binarios
{
    public class Tree<T>
    {
        private int size;
        private int height;
        public int Size { get => size;  set => size = value; }
        public int Height { get => height;  set => height = value; }
        public Node<T> RootNode { get => RootNode; private set => RootNode = value; }
        public string ProcessOrder { get => ProcessOrder; set => ProcessOrder = value; }

        public Tree(T data)
        {
            Size = 1;
            Height = 0;
            Node<T> RootNode = new Node<T>(data);
            ProcessOrder = "InOrder";
        }

        public Node <T> AddLeftChild(Node<T> nodo, T data)
        {
            if (nodo.LeftNode == null)
            {
                nodo.LeftNode = new Node<T>(data);
                return nodo.LeftNode;
            }
            throw new InvalidOperationException("invalid");
        }

        public Node <T> AddRightChild(Node<T> nodo, T data)
        {
            if (nodo.RightNode == null)
            {
                nodo.RightNode = new Node<T>(data);
                return nodo.RightNode;
            }

            throw new InvalidOperationException("invalid");
        }

        public void AddRoot(T data)
        {
            if (RootNode != null)
            {
                RootNode = new Node<T>(data);
            }
        }

        public void DeleteNode(Node<T> nodo, bool condition)
        {
            if (nodo.IsLeaf())
            {
                Node <T> padre = nodo.ParentNode;
                if (padre.LeftNode == nodo)
                {
                    padre.LeftNode = null;
                }
                if (padre.RightNode == nodo)
                {
                    padre.RightNode = null;
                }
            }
        }

        public void ForEach() // Pendiente
        {
            if (ProcessOrder == "InOrder")
            {

            }
            if (ProcessOrder == "PreOrder")
            {

            }
            else if (ProcessOrder == "PostOrder")
            {
              
            }
            else
            {
                throw new InvalidOperationException("invalid");
            }
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        public string PosOrder(Node<T> nodo, string valores) // Publico temporal
        {
            if (nodo.IsLeaf())
            {
                return valores += Convert.ToString(nodo.Data) + ", ";
            }
            if(nodo.LeftNode != null)
            {
                PosOrder(nodo.LeftNode, valores);
            }
            if(nodo.RightNode != null)
            {
                PosOrder(nodo.RightNode, valores);
            }

            return valores += Convert.ToString(nodo.Data) + ", ";
        }

        public override string ToString()
        {
            if (ProcessOrder == "PostOrder")
            {
                string valores = string.Empty;
                return PosOrder( RootNode, valores);
            }
            else
            {
                throw new InvalidOperationException("invalid");
            }
        }
    }
}
