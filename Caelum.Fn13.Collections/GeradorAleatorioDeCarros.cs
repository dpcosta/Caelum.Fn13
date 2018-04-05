using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Fn13.Collections
{
    public class GeradorAleatorioDeCarros
    {
        private Random random;

        public GeradorAleatorioDeCarros(Random random)
        {
            this.random = random;
        }

        private Cor CorAleatoria()
        {
            var cores = Enum.GetValues(typeof(Cor)).Cast<Cor>().ToList();
            var numeroAleatorio = random.Next(0, cores.Count - 1);
            return cores[numeroAleatorio];
        }

        private int AnoAleatorio()
        {
            return random.Next(1970, 2018);

        }

        private Modelo ModeloAleatorio()
        {
            var modelos = Modelo.Modelos.ToList();
            var numeroAleatorio = random.Next(0, modelos.Count - 1);
            return modelos[numeroAleatorio];
        }

        private Placa PlacaAleatoria()
        {
            //definição das 3 letras
            var letrasDisponiveis = "ABCDEFGHIJLMNKOPQRSTUWVYXZ";
            var primeiraLetra = letrasDisponiveis[random.Next(0, letrasDisponiveis.Length-1)];
            var segundaLetra = letrasDisponiveis[random.Next(0, letrasDisponiveis.Length - 1)];
            var terceiraLetra = letrasDisponiveis[random.Next(0, letrasDisponiveis.Length - 1)];

            //definição dos quatro números
            var primeiroNumero = random.Next(0, 9);
            var segundoNumero = random.Next(0, 9);
            var terceiroNumero = random.Next(0, 9);
            var quartoNumero = random.Next(0, 9);

            return new Placa($"{primeiraLetra}{segundaLetra}{terceiraLetra}-{primeiroNumero}{segundoNumero}{terceiroNumero}{quartoNumero}");

        }

        private string SequenciaNumericaAleatoria(byte tamanhoSequencia)
        {
            var sequencia = "";
            for (int i = 1; i < tamanhoSequencia; i++)
            {
                sequencia += random.Next(0, 9).ToString();
            }
            return sequencia;
        }

        private Pessoa PessoaAleatoria()
        {
            var nomes = new string[]
            {
                "Alberto", "Jorge", "Fulano", "Maria", "Renata", "Cláudia", "Pedro"
            };

            var sobrenomes = new string[]
            {
                "Pereira", "Siqueira", "Silva", "Barroso", "Carvalho", "Pedreira", "Laranjeira", "Miranda"
            };

            var nome = nomes[random.Next(0, nomes.Length - 1)];
            var sobrenome = sobrenomes[random.Next(0, sobrenomes.Length - 1)];


            return new Pessoa
            {
                Nome = $"{nome} {sobrenome}",
                CPF = SequenciaNumericaAleatoria(9),
                RG = SequenciaNumericaAleatoria(8)
            };
        }

        public Carro CarroAleatorio => new Carro
        {
            Placa = PlacaAleatoria(),
            Ano = AnoAleatorio(),
            Cor = CorAleatoria(),
            Modelo = ModeloAleatorio(),
            Proprietario = PessoaAleatoria()
        };

    }
}
