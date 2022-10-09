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
            while(true)
                Menu();
            
        }

        static void Menu()
        {
            //Introdução ao projeto (menu)

            while (true)
            {

                Console.WriteLine("Bem vindo ao Mini Projeto 1 de PSI!");
                Console.WriteLine("+---------------------------------+");

                //Array de strings para ditar as opções do menu
                string[] menuarr = new string[3] { "Opção 1", "Opção 2", "Opção 3" };

                //Foreach loop para mostrar ao utilizador as opções
                foreach (string item in menuarr)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("\nIntroduza a opção desejada: ");

                //Recebe o valor inserido
                string menu_val = Console.ReadLine();

                //Verificar se menu_val conversível a int32
                if (Int32.TryParse(menu_val, out int menu_val_int) == false) 
                {
                    Console.WriteLine("Opção Inválida! A retornar ao início.."); 
                    Thread.Sleep(5000); 
                    Console.Clear(); 

                    break; 
                }

                //Console.WriteLine(menu_val_int.GetType());

                //Criação de um dicionário de funções porque ao utilizar Switch;Case; o código ficava feio :)
                Dictionary<int, Func<int>> op = new Dictionary<int, Func<int>>
                {
                {1, op0},
                {2, op1},
                {3, op2 },
                };

                op[menu_val_int]();


                Console.ReadKey();
            }
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

        static int op2()
        {
            return 0;
        }

        
    }
}
