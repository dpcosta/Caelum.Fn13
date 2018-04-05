using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Fn13.Dictionary
{
    class Program
    {

        class Produto
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public double PrecoUnitario { get; set; }
        }


        static void Main()
        {

            var p1 = new Produto { Id = 1, Nome = "Livro", PrecoUnitario = 12.50 };
            var p2 = new Produto { Id = 2, Nome = "Macarrão", PrecoUnitario = 12.50 };
            var p3 = new Produto { Id = 3, Nome = "Feijão", PrecoUnitario = 12.50 };
            var p4 = new Produto { Id = 4, Nome = "Arroz", PrecoUnitario = 12.50 };
            var p5 = new Produto { Id = 5, Nome = "Caneta", PrecoUnitario = 12.50 };
            var p6 = new Produto { Id = 6, Nome = "Lápis", PrecoUnitario = 12.50 };

            var lista = new List<Produto> { p1, p2, p3, p4, p5, p6 };


            //como recuperar o produto cujo Id é 6?
            foreach (var p in lista)
            {
                if (p.Id == 6)
                {
                    Console.WriteLine("Produto id 6 é " + p.Nome);
                }
            }

            //ou...
            var mapa = new Dictionary<int, Produto>
            {
                { 1, p1 },
                { 2, p2 },
                { 3, p3 },
                { 4, p4 },
                { 5, p5 },
                { 6, p6 }
            };

            Console.WriteLine("Produto id 6 é " + mapa[6].Nome);

        }
    }
}
