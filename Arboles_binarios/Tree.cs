using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arboles_binarios
{
    public class Tree<T> : IEnumerable
    {
        private int size;
        private int height;
        private Node<T> rootNode;


        public int Size { get => getSize(); }
        public int? Height { get => getHeight();}
        public Node<T> RootNode { get => rootNode; private set => rootNode = value; }
        


        public enum ProcessOrder { InOrder, PreOrder, PostOrder }
        ProcessOrder ProcessElegido = ProcessOrder.InOrder;

        private List<T> valores = new List<T>();
        public Tree()
        {
            size = 0;
            RootNode = null;
        }
        public Tree(T data)
        {
            size = 1;
            RootNode = new Node<T>(data, null, this);
        }

        private bool HasChild(Node<T> nodo)
        {
            if (nodo.IsLeaf())
            {
                return false;
            }
            else if (nodo.LeftNode != null && nodo.RightNode != null)
            {
                return false;
            }
            return true;
        }
        public Node<T> AddLeftChild(Node<T> nodo, T data)
        {
            if (nodo.tree != this)
            {
                throw new InvalidOperationException("Invalid Operation, cannot add a node from another tree");
            }
            if (nodo.LeftNode == null)
            {
                nodo.LeftNode = new Node<T>(data, nodo, this);
                return nodo.LeftNode;
            }
            throw new InvalidOperationException("invalid");
        }

        public Node<T> AddRightChild(Node<T> nodo, T data)
        {
            if (nodo.tree != this)
            {
                throw new InvalidOperationException("Invalid Operation, cannot add a node from another tree");
            }
            if (nodo.RightNode == null)
            {
                nodo.RightNode = new Node<T>(data, nodo, this);
                return nodo.RightNode;
            }

            throw new InvalidOperationException("invalid");
        }
        public int? getHeight()
        {
            if (isEmpty())
            {

                return null;
            }
            int maxH = RootNode.Height;

            maxH = MaxHeight(RootNode, maxH);

            return maxH;
        }

        private int MaxHeight(Node<T> nodo, int maxh)
        {
            if (nodo.LeftNode != null)
            {
                maxh = MaxHeight(nodo.LeftNode, maxh);
            }
            if (nodo.RightNode != null)
            {
                maxh = MaxHeight(nodo.RightNode, maxh);
            }
            if (nodo.Height>maxh)
            {
                maxh = nodo.Height;
            }
            return maxh;
        }
        public int getSize()
        {
            valores.Clear();
            PosTOrder(rootNode);
            return valores.Count();
        }
        public void AddRoot(T data)
        {
            if (RootNode == null)
            {
                RootNode = new Node<T>(data, null, this);
            }
            else
            {
                throw new InvalidOperationException("Root Already Exists");
            }
        }

        public void DeleteNode(Node<T> nodo, bool condition)
        {
            if(nodo.tree != this)
            {
                throw new InvalidOperationException("Invalid Operation, cannot delete a node from another tree");
            }
            if (!condition){
                if (nodo.IsLeaf() || HasChild(nodo))
                {
                    if (RootNode == nodo)
                    {
                        RootNode = null;
                    }
                    else
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
                else
                {
                    throw new InvalidOperationException("Invalid Operation, this node is not a leaf or has more than one children");
                }
            }
            else
            {   
                if(RootNode == nodo)
                {
                    RootNode = null;
                }
                else {
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
        }

        public string setProcessOrder(int num)
        {
            switch (num)
            {
                case 1:
                    ProcessElegido = ProcessOrder.InOrder;
                    return "ProcessOrder set to InOrder";
                case 2:
                    ProcessElegido = ProcessOrder.PreOrder;
                    return "ProcessOrder set to PreOrder";
                case 3:
                    ProcessElegido = ProcessOrder.PostOrder;
                    return "ProcessOrder set to PostOrder";
            }
            throw new InvalidOperationException("Invalid Argument: 1 -> InOrder, 2 -> PreOrder, 3 -> PostOrder");
        }

        private void SetNode(Node <T> currentNode, T data)
        {
            if(Convert.ToInt32(currentNode.Data) > Convert.ToInt32(data))
            {
                if (currentNode.LeftNode == null)
                {
                    currentNode.LeftNode = new Node<T>(data, currentNode, this);
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
                    currentNode.RightNode = new Node<T>(data, currentNode, this);
                }
                else
                {
                    SetNode(currentNode.RightNode, data);
                }
            }
        }

        public string TreeSort(T[] array)
        {
            if(RootNode == null)
            {
                RootNode = new Node<T>(array[0], null, this);
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
            else
            {
                throw new InvalidOperationException("Tree has data already.");
            }

        }

        public bool isEmpty()
        {
            return Size == 0;
        }

        private void PosTOrder(Node<T> nodo, Action<T> accion = null) // Publico temporal
        {
            if (nodo == null)
            {
                return;
            }
            if (nodo.LeftNode != null)
            {
                PosTOrder(nodo.LeftNode, accion);
            }
            if(nodo.RightNode != null)
            {
                PosTOrder(nodo.RightNode, accion);
            }
            if (accion != null)
            {
                accion(nodo.Data);
            }
            valores.Add(nodo.Data);
            return;
        }

        private void PreOrder(Node<T> nodo, Action<T> accion = null) // Publico temporal
        {
            if (nodo == null)
            {
                return;
            }
            if (accion != null)
            {
                accion(nodo.Data);
            }
            valores.Add(nodo.Data);
            if (nodo.LeftNode != null)
            {
                PreOrder(nodo.LeftNode, accion);
            }
            if (nodo.RightNode != null)
            {
                PreOrder(nodo.RightNode, accion);
            }
            return;
        }

        private void InOrder(Node<T> nodo, Action<T> accion = null) // Publico temporal
        {
            if(nodo == null)
            {
                return;
            }
            if (nodo.LeftNode != null)
            {
                InOrder(nodo.LeftNode, accion);
            }
            if (accion != null)
            {
                accion(nodo.Data);
            }
            valores.Add(nodo.Data);
            if (nodo.RightNode != null)
            {
                InOrder(nodo.RightNode, accion);
            }
            return;
        }

        public void ForEach(Action<T> accion)
        {
            if (ProcessElegido == ProcessOrder.PostOrder)
            {
                PosTOrder(RootNode, accion);   
            }
            if (ProcessElegido == ProcessOrder.PreOrder)
            {
                PreOrder(RootNode, accion);
            }
            if (ProcessElegido == ProcessOrder.InOrder)
            {
                InOrder(RootNode, accion);
            }
        }

        public override string ToString()
        {
            if (ProcessElegido == ProcessOrder.PostOrder)
            {
                valores.Clear();
                PosTOrder(RootNode);
                return string.Join(",", valores.ToArray());
            }
            if (ProcessElegido == ProcessOrder.PreOrder)
            {
                valores.Clear();
                PreOrder(RootNode);
                return string.Join(",", valores.ToArray());
            }
            if (ProcessElegido == ProcessOrder.InOrder)
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

        private class Enumerator : IEnumerator
        {
            private int Index;
            private List<T> list = new List<T>();
            public Enumerator(Tree<T> tree)
            {
                tree.ForEach(e => list.Add(e));
                Index = -1;
            }

            public object Current => list[Index];

            public bool MoveNext()
            {
                if (Index + 1 == list.Count())
                {
                    return false;
                }
                Index++;
                return true;
            }

            public void Reset() => Index = -1;
        }

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }
    }
}
