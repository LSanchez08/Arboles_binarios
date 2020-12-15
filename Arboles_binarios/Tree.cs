using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arboles_binarios
{
    public class Tree<T> // : IEnumerable
    {
        private int size;
        private int height;
        private Node<T> rootNode;


        public int Size { get => size; set => size = value; }
        public int Height { get => height; set => height = value; }
        public Node<T> RootNode { get => rootNode; private set => rootNode = value; }


        public enum ProcessOrder { InOrder, PreOrder, PostOrder }
        ProcessOrder ProcessElegido = ProcessOrder.InOrder;



        private List<T> valores = new List<T>();

        public Tree(T data)
        {
            Size = 1;
            Height = 0;
            RootNode = new Node<T>(data);
        }

        public Node<T> AddLeftChild(Node<T> nodo, T data)
        {
            if (nodo.LeftNode == null)
            {
                nodo.LeftNode = new Node<T>(data);
                return nodo.LeftNode;
            }
            throw new InvalidOperationException("invalid");
        }

        public Node<T> AddRightChild(Node<T> nodo, T data)
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
                Node<T> padre = nodo.ParentNode;
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

        /*public void ForEach() // Pendiente
        {
            if (processOrder == "InOrder")
            {

            }
            if (processOrder == "PreOrder")
            {

            }
            else if (processOrder == "PostOrder")
            {

            }
            else
            {
                throw new InvalidOperationException("invalid");
            }
        }
        */
        private void SetNode(Node <T> currentNode, T data)
        {
            if(Convert.ToInt32(currentNode.Data) > Convert.ToInt32(data))
            {
                if (currentNode.LeftNode == null)
                {
                    currentNode.LeftNode = new Node<T>(data);
                }
                else
                {
                    SetNode(currentNode.LeftNode, data);
                }
            }
            else
            {
                if (currentNode.RightNode == null)
                {
                    currentNode.RightNode = new Node<T>(data);
                }
                else
                {
                    SetNode(currentNode.RightNode, data);
                }
            }
        }

        public string TreeSort(T[] array)
        {
            // T[] arbol;
            // [6,                              |3,2,4,9,8,5,6]
            for (int i = 1; i < array.Length; i++)
            {
                SetNode(RootNode, array[i]);
            }

            valores.Clear();
            InOrder(RootNode);
            return string.Join(",", valores.ToArray());
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

        public void PreOrder(Node<T> nodo) // Publico temporal
        {
            valores.Add(nodo.Data);
            if (nodo.LeftNode != null)
            {
                PreOrder(nodo.LeftNode);
            }
            if (nodo.RightNode != null)
            {
                PreOrder(nodo.RightNode);
            }
            return;
        }

        public void InOrder(Node<T> nodo) // Publico temporal
        {
            if (nodo.LeftNode != null)
            {
                InOrder(nodo.LeftNode);
            }
            valores.Add(nodo.Data);
            if (nodo.RightNode != null)
            {
                InOrder(nodo.RightNode);
            }
            return;
        }

        /*public override string ToString()
        {
            if (processOrder == "PostOrder")
            {
                valores.Clear();
                PosOrder(RootNode);
                return string.Join(",", valores.ToArray());
            }
            if (processOrder == "PreOrder")
            {
                valores.Clear();
                PreOrder(RootNode);
                return string.Join(",", valores.ToArray());
            }
            if (processOrder == "InOrder")
            {
                valores.Clear();
                InOrder(RootNode);
                return string.Join(",", valores.ToArray());
            }
            else
            {
                throw new InvalidOperationException("invalid");
            }
        }
        */


        public void ForEach(Action<T> accion)
        {
            throw new InvalidOperationException("invalid");
        }

    }
}
