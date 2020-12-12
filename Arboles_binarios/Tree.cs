using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arboles_binarios
{
    public class Tree<T> : ITree<T>
    {
        public int size { get => size; private set => size = value; }
        public int height { get => height; private set => height = value; }
        public Node<T> RootNode { get => RootNode; private set => RootNode = value; }
        public string ProcessOrder { get => ProcessOrder; set => ProcessOrder = value; }

        public Tree(string processOrder, T data)
        {
            this.size = 1;
            this.height = 0;
            Node<T> RootNode = new Node<T>(data);
            ProcessOrder = processOrder;
        }

        public void AddLeftChild(Node<T> nodo, T data)
        {
            if (nodo.LeftNode != null)
            {
                nodo.LeftNode = new Node<T>(data);
            }
        }

        public void AddRightChild(Node<T> nodo, T data)
        {
            if (nodo.RightNode != null)
            {
                nodo.RightNode = new Node<T>(data);
            }
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
            throw new NotImplementedException();
        }

        public bool isEmpty()
        {
            return size == 0;
        }
    }
}
