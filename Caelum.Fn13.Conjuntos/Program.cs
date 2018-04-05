using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Fn13.Conjuntos
{
    class Program
    {
        static void Main(string[] args)
        {

            var lista = new List<string>
            {
                "maçã",
                "laranja",
                "limão",
                "banana",
                "uva"
            };

            lista.Add("uva");
            Console.WriteLine(lista.Count);

            var conjunto = new HashSet<string>
            {
                "maçã",
                "laranja",
                "limão",
                "banana",
                "uva"
            };
            conjunto.Add("uva");
            Console.WriteLine(conjunto.Count);


            //como o conjunto sabe que o elemento está duplicado?
            //usando o método GetHashCode()
            var s1 = "uva";
            var s2 = "uva";
            Console.WriteLine(s1.GetHashCode());
            Console.WriteLine(s2.GetHashCode());


            //mas o código abaixo não funciona...
            //Console.WriteLine(conjunto[1]);

            //já em listas sim...
            Console.WriteLine(lista[1]);

        }
    }
}
