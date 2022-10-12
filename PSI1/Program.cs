using System;
using System.Collections.Generic;
using System.Globalization;
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
            Console.ForegroundColor = ConsoleColor.Blue;
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
                {4, op3 },
                };

                try
                {
                    op[menu_val_int]();
                }
                catch (System.Collections.Generic.KeyNotFoundException)
                {
                    Console.WriteLine("Opção Inválida! A retornar ao início..");
                    Thread.Sleep(5000);
                    Console.Clear();

                    break;
                }     


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
            //Algoritmo de correção de texto (Converte em maiúsculas para a primeira letra de uma palavra no início da frase e vice versa para palavras que estão no meio e fim.)
            

            Console.WriteLine("Bem vindo ao algoritmo de correção de texto.\nPor favor introduza um texto.");

            //Recebe texto
            string text = Console.ReadLine();

            //Tornar a primeira letra de uma string uppercase.
            List<string> corr_text = new List<string>();

            int b = 0;
            foreach (string i in text.Split(' ')) 
            {
                
                string result = i;

                result = result.ToLower();

                //Se for a primeira palavra de uma string capitaliza a primeira letra
                if (b == 0)
                {
                    char max = Char.ToUpper(result[0]);
                    result = max + result.Substring(1);
                }

                b++;

                //Se a string contém ".", altera o contador b para 0. Isto faz com que a próxima palavra seja capitalizada.
                if (result.Contains("."))
                {
                    b = 0;
                }

                if (result.Contains(",") || result.Contains("."))
                {
                    if (result[result.Length-1] == ' ')
                    {
                        continue;
                    }
                    else
                    {
                        result = result + " ";
                    }
                }
                
                corr_text.Add(result);
                
            }


            foreach (string i in corr_text)
            {
                Console.Write(i);
            }

            return 0;
        }

        static int op3 ()
        {
            //Caracteres não impresos
            //Conversão de tipos de dinheiro (EUR - USD) por exemplo

            while (true)
            {

                Console.WriteLine("Bem vindo ao programa de conversão da moeda de vários países");
                Console.WriteLine("1. - EUR - USD\n2. - USD - EUR\n3. - EUR - GBP\n4. - GBP - EUR\n5. - JPY - EUR\n6. - EUR - JPY");

                Console.WriteLine("Insira a sua opção..");
                string exchange = Console.ReadLine();

                if (Int32.TryParse(exchange, out int exchange_val_int) == false)
                {
                    Console.WriteLine("Opção Inválida! A retornar ao início..");
                    Thread.Sleep(5000);
                    Console.Clear();

                    break;
                }

                Console.WriteLine("Introduza o valor da moeda que quer converter..");

                string moeda_str = Console.ReadLine();

                if (Int32.TryParse(moeda_str, out int moeda) == false)
                {
                    Console.WriteLine("Opção Inválida! A retornar ao início..");
                    Thread.Sleep(5000);
                    Console.Clear();

                    break;
                }

                if (exchange_val_int == 1)
                {
                    Console.WriteLine(moeda + )
                }
                else if (exchange_val_int == 2)
                {

                }
                else if (exchange_val_int == 3)
                {

                }
                else if (exchange_val_int == 4)
                {

                }
                else if (exchange_val_int == 5)
                {

                }
                else if (exchange_val_int == 6)
                {

                }
                else
                {
                    Console.WriteLine("Opção Inválida! A retornar ao início..");
                    Thread.Sleep(5000);
                    Console.Clear();

                    break;
                }
            }

            return 0;
        }

        
    }
}
