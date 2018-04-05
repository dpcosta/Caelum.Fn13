using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Fn13.Listas
{
    class Program
    {
        static void Main()
        {

            double[] numeros = new double[4];

            numeros[0] = 1.0;
            numeros[1] = 2.0;
            numeros[2] = 3.0;
            numeros[3] = 4.0;


            //e para inserir o número 1.5?


            //e para inserir o 5º elemento?


            //e para remover o 3º elemento?


            List<double> listaNumeros = new List<double>();

            listaNumeros.Add(1.0);
            listaNumeros.Add(2.0);
            listaNumeros.Add(3.0);
            listaNumeros.Add(4.0);

            foreach (var item in listaNumeros)
            {
                Console.WriteLine(item);
            }

            //e para inserir o número 1.5?
            listaNumeros.Insert(1, 1.5);
            foreach (var item in listaNumeros)
            {
                Console.WriteLine(item);
            }


            //e para inserir um 5º elemento?
            listaNumeros.Add(20.0);


            //e para remover o 3º elemento?
            listaNumeros.RemoveAt(2);



        }
    }
}
