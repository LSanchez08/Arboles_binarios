﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arboles_binarios
{
    public interface ITree<T>
    {
        int size { get; } // El numero total de nodos
        int height { get; } // La altura del arbol del nodo raiz
        Node<T> RootNode { get;} //Es el nodo raiz
        string ProcessOrder { get; set; } // una enumeración con posibles valores InOrder (default), PreOrder, y PostOrder
        bool isEmpty(); // retorna true si árbol no posee ningún nodo
        void AddRoot(T data); // crea el nodo raíz, devuelve nodo creado, excepción si ya existe
        void AddLeftChild(Node<T> nodo, T data); // agrega al nodo especificado un nodo hijo izquierdo, excepción si ya existe
        void AddRightChild(Node<T> nodo, T data); // agrega al nodo especificado un nodo hijo derecho, excepción si ya existe
        void DeleteNode(Node <T> nodo, bool condition); // ???
        void ForEach();

    }
}
