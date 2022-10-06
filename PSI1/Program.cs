using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSI1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Introdução ao projeto (menu)

            Console.WriteLine("Bem vindo ao Mini Projeto 1 de PSI!");
            Console.WriteLine("+---------------------------------+");

            string[] menuarr = new string[3] {"Opção 1", "Opção 2", "Opção 3"};

            foreach (string item in menuarr)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nIntroduza a opção desejada: ");
            string menu_val = Console.ReadLine();

            Dictionary<int, Func<int>> proc = new Dictionary<int, Func<int>>
            {
                {0, op0},
                {1, op1},
            };

            op[menu_val]();


            Console.ReadKey();
        }

        static Int32 op1()
        {
            //Vetores
            
            string[,] vector = { { "Linha 1", "a", "b", "c" }, { "Linha 2", "d", "e", "f" }, { "Linha 3", "g", "h", "i" } };

            Console.WriteLine("\n--------------------+");

            for (int i = 0; i < vector.GetLength(0); i++)
            {
                for (int j = 0; j < vector.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        Console.Write(vector[i, j] + " | ");
                    }
                    else if (i == 1)
                    {
                        Console.Write(vector[i, j] + " | ");
                    }
                    else if (i == 2)
                    {
                        Console.Write(vector[i, j] + " | ");
                    }
                }
                Console.WriteLine("\n--------------------+");
            }
            return 0;
        }

        static Int32 op0()
        {
            //Pedindo Valores ao utilizador

            Console.Write("Olá! Qual o seu nome? ");
            string name = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Olá {0}! Bem vindo ao Mini Projeto 1 de PSI!", name);

            Console.WriteLine("Quantos anos tem?");
            string age = Console.ReadLine();

            return Convert.ToInt32(age); // Conversão string-int32 + retorna valor
        }
    }
}
