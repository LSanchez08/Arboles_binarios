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
        private Node<T> rootNode;
        private string processOrder;
        public int Size { get => size;  set => size = value; }
        public int Height { get => height;  set => height = value; }
        public Node<T> RootNode { get => rootNode; private set => rootNode = value; }
        public string ProcessOrder { get => processOrder; set => processOrder = value; }

        private List<T> valores = new List<T>();

        public Tree(T data)
        {
            Size = 1;
            Height = 0;
            RootNode = new Node<T>(data);
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

        public void PosOrder(Node<T> nodo) // Publico temporal
        {
            if (nodo.IsLeaf())
            {
                valores.Add(nodo.Data);
                return;
            }
            if(nodo.LeftNode != null)
            {
                PosOrder(nodo.LeftNode);
            }
            if(nodo.RightNode != null)
            {
                PosOrder(nodo.RightNode);
            }
            valores.Add(nodo.Data);
            return;
        }

        public override string ToString()
        {
            if (ProcessOrder == "PostOrder")
            {
                valores.Clear();
                PosOrder(RootNode);
                return string.Join(",", valores.ToArray());
            }
            else
            {
                throw new InvalidOperationException("invalid");
            }
        }
    }
}
