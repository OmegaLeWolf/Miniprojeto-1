using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace PSI1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Codificação do text UTF-8
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //Muda a cor do texto para azul
            Console.ForegroundColor = ConsoleColor.Blue;
            while(true)
                Menu();
            
        }

        static void Menu()
        {
            //Introdução ao projeto (menu)

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Bem vindo ao Mini Projeto 1 de PSI!");
                Console.WriteLine("+---------------------------------+");

                //Array de strings para ditar as opções do menu
                string[] menuarr = new string[4] { "[1] - Apresentação de uma tabela com vetores", "[2] - Algoritmo de Correção de texto", "[3] - Conversão de moeda", "[4] - Sair" };

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
                    //Mostra caixa de texto
                    MessageBox.Show("Opção Inválida! A retornar ao início..", "Erro");

                    Thread.Sleep(2000);
                    Console.Clear();

                    break; 
                }

                //Console.WriteLine(menu_val_int.GetType());

                //Criação de um dicionário de funções porque ao utilizar Switch;Case; o código ficava feio :)
                Dictionary<int, Func<int>> op = new Dictionary<int, Func<int>>
                {
                {1, op1},
                {2, op2},
                {3, op3},
                {4, op4},
                };

                try
                {
                    op[menu_val_int]();
                }
                catch (System.Collections.Generic.KeyNotFoundException)
                {
                    //Mostra caixa de texto
                    MessageBox.Show("Opção Inválida! A retornar ao início..", "Erro");
                    
                    Thread.Sleep(2000);
                    Console.Clear();

                    break;
                }     


                Console.ReadKey();
            }
        }

        static Int32 op1()
        {
            Console.Clear();
            //Vetores
            
            //Criação de vetor
            string[,] vector = { { "Linha 1", "a", "b", "c" }, { "Linha 2", "d", "e", "f" }, { "Linha 3", "g", "h", "i" } };

            Console.WriteLine("\n--------------------+");

            //Mostra os valores guardados no vetor em uma tabela
            for (int i = 0; i < vector.GetLength(0); i++)
            {
                for (int j = 0; j < vector.GetLength(1); j++)
                {
                    
                    switch(i)
                    {
                        case 0:
                        case 1: 
                        case 2:
                            Console.Write(vector[i, j] + " | ");
                            break;
                    }

                }
                Console.WriteLine("\n--------------------+");
            }
            Console.WriteLine("\nCarregue em Enter para continuar...");
            Console.ReadKey();
            return 0;
            
        }

        static int op2()
        {
            //Algoritmo de correção de texto (Converte em maiúsculas para a primeira letra de uma palavra no início da frase e vice versa para palavras que estão no meio e fim.)

            Console.Clear();
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
                corr_text.Add(result);
                
            }


            //Verifica em que índice estão os espaços da string original
            List<int> spaces = new List<int>();

            //Verificação de comprimento de caracteres
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    spaces.Add(i);
                }
            }


            //Cria uma string que adiciona espaços à string alterada (criando outra string pois strings são imutáveis)
            var builder = new StringBuilder();

            int a = 0;
            foreach (string i in corr_text)
            {
                foreach (var c in i)
                {
                    //Se lista spaces ter o valor a dentro da lista
                    if (spaces.Contains(a))
                    {
                        //Adiciona um espaço à nova string
                        builder.Append(' ');
                        a++;
                        
                    }
                    //Adiciona o caractere c à nova string
                    builder.Append(c);

                    a++;
                }
            }

            Console.Write("\n\nTexto Corrigido: " + builder.ToString());

            

            return 0;
        }

        static int op3 ()
        {
            Console.Clear();

            //Caracteres não impresos
            //Conversão de tipos de dinheiro (EUR - USD) por exemplo

            do
            {
                //Buscar culturas para a utilização do símbolo da moeda mais tarde
                CultureInfo usUs = new CultureInfo("us-Us");
                CultureInfo ptPt = new CultureInfo("pt-PT");
                CultureInfo enGB = new CultureInfo("en-GB");
                CultureInfo jpJP = new CultureInfo("jp-JP");


                //Menu
                Console.WriteLine("Bem vindo ao programa de conversão da moeda de vários países");
                Console.WriteLine("1. - EUR - USD\n2. - USD - EUR\n3. - EUR - GBP\n4. - GBP - EUR\n5. - JPY - EUR\n6. - EUR - JPY\n7. - Sair");

                Console.WriteLine("Insira a sua opção..");
                string exchange = Console.ReadLine();

                //Verifica se valor introduzido é int
                if (Int32.TryParse(exchange, out int exchange_val_int) == false)
                {
                    //Mostra caixa de texto
                    MessageBox.Show("Opção Inválida! A retornar ao início..", "Erro");

                    Thread.Sleep(2000);
                    Console.Clear();

                    break;
                }

                if (exchange_val_int == 7)
                {
                    return 0;
                }

                Console.WriteLine("Introduza o valor da moeda que quer converter..");

                string moeda_str = Console.ReadLine();

                //Verifica se o valor introduzido é int
                if (Double.TryParse(moeda_str, out double moeda) == false)
                {
                    //Mostra caixa de texto
                    MessageBox.Show("Opção Inválida! A retornar ao início..", "Erro");

                    Thread.Sleep(2000);
                    Console.Clear();

                    break;
                }

                //EUR - USD
                if (exchange_val_int == 1)
                {
                    double conv_rate = 1.03;
                    double usd = moeda / conv_rate;


                    Console.WriteLine(moeda + ptPt.NumberFormat.CurrencySymbol + " correspondem a " + Math.Round(usd, 2) + usUs.NumberFormat.CurrencySymbol);

                }

                //USD - EUR
                else if (exchange_val_int == 2)
                {
                    double conv_rate = 0.97;
                    double usd = moeda / conv_rate;


                    Console.WriteLine(moeda + usUs.NumberFormat.CurrencySymbol + " correspondem a " + Math.Round(usd, 2) + ptPt.NumberFormat.CurrencySymbol);
                }

                //EUR - GBP
                else if (exchange_val_int == 3)
                {
                    double conv_rate = 1.14;
                    double usd = moeda / conv_rate;


                    Console.WriteLine(moeda + ptPt.NumberFormat.CurrencySymbol + " correspondem a " + Math.Round(usd, 2) + enGB.NumberFormat.CurrencySymbol);
                }

                //GBP - EUR
                else if (exchange_val_int == 4)
                {
                    double conv_rate = 0.87;
                    double usd = moeda / conv_rate;


                    Console.WriteLine(moeda + enGB.NumberFormat.CurrencySymbol + " correspondem a " + Math.Round(usd, 2) + ptPt.NumberFormat.CurrencySymbol);
                }

                //JPY - EUR
                else if (exchange_val_int == 5)
                {
                    double conv_rate = 142.55;
                    double usd = moeda / conv_rate;


                    Console.WriteLine(moeda + jpJP.NumberFormat.CurrencySymbol + " correspondem a " + Math.Round(usd, 3) + ptPt.NumberFormat.CurrencySymbol);
                }

                //EUR - JPY
                else if (exchange_val_int == 6)
                {
                    double conv_rate = 0.0070;
                    double usd = moeda / conv_rate;


                    Console.WriteLine(moeda + ptPt.NumberFormat.CurrencySymbol + " correspondem a " + Math.Round(usd, 2) + jpJP.NumberFormat.CurrencySymbol);
                }

          
                else
                {
                    //Mostra caixa de texto
                    MessageBox.Show("Opção Inválida! A retornar ao início..", "Erro");

                    Thread.Sleep(2000);
                    Console.Clear();

                    break;
                }

                Console.WriteLine("\nCarregue em Enter para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
            while (true);

            return 0;
        }

        static int op4()
        {
            Environment.Exit(1);
            return 0;
        }

        
    }
}
