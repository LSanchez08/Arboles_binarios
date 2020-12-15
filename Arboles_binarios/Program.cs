using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arboles_binarios
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddLeft, AddRight
            Tree<int> Pino = new Tree<int>(0); // Nucleo
            // Primer mitad izquierda
            Node<int> n1 = Pino.AddLeftChild(Pino.RootNode, 1); // 1 Hijo de 0
            Node<int> n2 = Pino.AddLeftChild(n1, 2); // 2 Hijo de 1
            Node<int> n3 = Pino.AddRightChild(n1, 3); // 3 Hijo de 1
            Node<int> n4 = Pino.AddLeftChild(n2, 4); // 4 Hijo de 2
            Node<int> n5 = Pino.AddRightChild(n2, 5); // 5 Hijo de 2
            Node<int> n6 = Pino.AddLeftChild(n4, 6); // 6 Hijo de 4
            // Mitad derecha
            Node<int> n7 = Pino.AddRightChild(Pino.RootNode, 7); // 7 Hijo de 0
            Node<int> n8 = Pino.AddRightChild(n7, 8); // 8 Hijo de 7
            Node<int> n9 = Pino.AddLeftChild(n8, 9); // 9 Hijo de 8
            Node<int> n10 = Pino.AddRightChild(n8, 10); // 10 Hijo de 8
            Node<int> n11 = Pino.AddRightChild(n9, 11); // 11 Hijo de 9

            // No permite agregar hijos en caso de que ya existan
            // Node<int> n12 = Pino.AddLeftChild(n1, 50);
            // Node<int> n13 = Pino.AddRightChild(n8, 23);


            // No permite agregar root a un arbol ya existente
            //Pino.AddRoot(5);
            Tree<int> Roble = new Tree<int>();
            Roble.AddRoot(5);
            Console.WriteLine($"Root de Roble agregado: {Roble.RootNode.Data}");
            Console.WriteLine("\n --------------------------------------- \n");


            Console.WriteLine(Pino.setProcessOrder(1));
            string tree_inOrder = Pino.ToString();
            Console.WriteLine($"InOrder: {tree_inOrder} \n");

            Console.WriteLine(Pino.setProcessOrder(2));
            string tree_preOrder = Pino.ToString();
            Console.WriteLine($"PreOrder: { tree_preOrder}\n");

            Console.WriteLine(Pino.setProcessOrder(3));
            string tree_postOrder = Pino.ToString();
            Console.WriteLine($"PostOrder: {tree_postOrder}\n");

            Console.WriteLine("Pino Height: " + Pino.Height);
            Console.WriteLine("\n --------------------------------------- \n");

            //Metodo ForEach
            int sum = 0;
            Pino.ForEach(value => sum += value);
            Console.WriteLine("sum: " + sum);

            Console.WriteLine("\n --------------------------------------- \n");

            //Size
            Console.WriteLine("Size:" + Pino.Size);

            Console.WriteLine("\n --------------------------------------- \n");


            // Delete leaf
            Pino.DeleteNode(n5, false);
            Console.WriteLine("5 Deleted:" + Pino.ToString());
            Console.WriteLine("Size:" + Pino.Size);
            Console.WriteLine("Tree Height: " + Pino.Height);
            Console.WriteLine("\n");
            // Delete root o parent node
            Pino.DeleteNode(Pino.RootNode, true);
            Console.WriteLine("Root Deleted:" + Pino.ToString());
            Console.WriteLine("Size:" + Pino.Size);
            Console.WriteLine("Tree Height: " + Pino.Height);

            //Tree Sort
            Console.WriteLine("\n --------------------------------------- \n");

            int[] List = {25, 148, 26, -3, 89};
            Tree<int> Acacia = new Tree<int>();

            string ordenado = Acacia.TreeSort(List);
            Console.WriteLine(ordenado);

            Console.WriteLine("\n --------------------------------------- \n");

            // foreach aplicado
            Console.Write("[ ");
            foreach (int e in Acacia)
            {
                Console.Write($"{e} ");
            }
            Console.WriteLine("]");

            Console.ReadKey();

        }
    }
}
