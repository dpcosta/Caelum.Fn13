using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Fn13.Excecoes
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Início do método Main");
            Metodo1();
            Console.WriteLine("Fim do método Main");
        }

        private static void Metodo1()
        {
            Console.WriteLine("Início do método 1");
            Metodo2();
            Console.WriteLine("Fim do método 1");
        }

        private static void Metodo2()
        {
            Console.WriteLine("Início do método método 2");
            Metodo2();
            //for (int i = 5; i >= 0; i--)
            //{
            //    Console.WriteLine("Divisão é " + 2/i);
            //}
            Console.WriteLine("Fim do método método 2");
        }
    }
}
