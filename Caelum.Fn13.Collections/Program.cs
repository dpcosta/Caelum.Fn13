using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Fn13.Collections
{
    class Program
    {
        static void Main()
        {
            var repo = new RepositorioDeCarros();

            var random = new Random();
            for (int i = 0; i < 10000; i++)
            {
                var carro = new GeradorAleatorioDeCarros(random).CarroAleatorio;
                Console.WriteLine(carro);
                repo.Incluir(carro);
            }

            //Usando a idéia do padrão Repositório
            //incluir n carros, MUITOS! dez mil, talvez
            //alterar 1 carro
            //excluir 1 carro


            //pesquisar carros por algum critério específico
            //- ano
            //- modelo
            //- marca
            //- cor
            //- proprietário

            Console.WriteLine("=========================================");
            var modelo = Modelo.Modelos.ElementAt(2);
            Console.WriteLine($"Carros cujo modelo é {modelo.Nome}");
            var carros = repo.CarrosComModelo(modelo);
            foreach (var c in carros)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("{0} carros encontrados.", carros.Count());

            Console.WriteLine("=========================================");
            var ano = 2000;
            Console.WriteLine($"Carros cujo ano é {ano}");
            carros = repo.CarrosDoAno(ano);
            foreach (var c in carros)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("{0} carros encontrados.", carros.Count());

            Console.WriteLine("=========================================");
            var cor = Cor.Azul;
            Console.WriteLine($"Carros cuja cor é {cor}.");
            carros = repo.CarrosDaCor(cor);
            foreach (var c in carros)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("{0} carros encontrados.", carros.Count());


            Console.WriteLine("=========================================");
            var marca = Marca.Fiat;
            Console.WriteLine($"Carros cuja marca é {marca}.");
            carros = repo.CarrosDaMarca(marca);
            foreach (var c in carros)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("{0} carros encontrados.", carros.Count());

            Console.WriteLine("=========================================");
            Console.WriteLine($"Carros cujo proprietário começa com a letra C...");
            //e agora?
            //LINQ!!
            //olha que LINDO!
            carros = repo.Todos.Where(c => c.Proprietario.Nome.StartsWith("C", StringComparison.CurrentCultureIgnoreCase));
            foreach (var c in carros)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("{0} carros encontrados.", carros.Count());



            Console.WriteLine("Gravando os carros em CSV...");
            repo.Gravar(new CSVSerializer());
            Console.WriteLine("Fim da gravação!");
        }
    }
}
