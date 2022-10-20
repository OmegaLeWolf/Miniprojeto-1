using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PSI2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //Cores
            Console.BackgroundColor= ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            
            //Tamanho da Janela
            int width = Console.WindowWidth/2;
            int height = Console.WindowHeight/4;
            Console.SetWindowSize(width, height);

            //Func
            contador();
        }
        static void contador()
        {
            int i = 0;
            while (true)
            {
                Console.WriteLine($"{i} segundos passaram desde que o programa foi aberto");
                i++;
                Thread.Sleep(1000);
                Console.Clear();
                
            }
        }
    }
}
