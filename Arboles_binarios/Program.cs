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
            Tree<int> Pino = new Tree<int>(0); // Nucleo
            // Primer mitad izquierda
            Node<int> n1 = Pino.AddLeftChild(Pino.RootNode,1); // 1 Hijo de 0
            Node<int> n2 = Pino.AddLeftChild(n1, 2); // 2 Hijo de 1
            Node<int> n3 = Pino.AddRightChild(n1, 3); // 3 Hijo de 1
            Node<int> n4 = Pino.AddLeftChild(n2, 4); // 4 Hijo de 2
            Node<int> n5 = Pino.AddLeftChild(n2, 5); // 5 Hijo de 2
            Node<int> n6 = Pino.AddLeftChild(n4, 6); // 6 Hijo de 4
            // Mitad derecha
            Node<int> n7 = Pino.AddRightChild(Pino.RootNode, 7); // 7 Hijo de 0
            Node<int> n8 = Pino.AddRightChild(n7, 8); // 8 Hijo de 7
            Node<int> n9 = Pino.AddLeftChild(n8, 9); // 9 Hijo de 8
            Node<int> n10 = Pino.AddRightChild(n8, 10); // 10 Hijo de 8
            Node<int> n11 = Pino.AddRightChild(n9, 11); // 11 Hijo de 9

            Pino.ProcessOrder = "PostOrder";
            // string tree = Pino.ToString();

            // Console.WriteLine(tree);
            Console.ReadKey();
        }
    }
}
