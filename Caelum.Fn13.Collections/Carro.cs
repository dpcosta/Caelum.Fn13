using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Caelum.Fn13.Collections
{
    public class Placa
    {
        public string Valor { get; private set; }

        private bool PlacaValida(string valor)
        {
            // uma placa deve começar com 3 letras seguidas de um hífen e 4 números
            string pattern = @"[A-Z]{3}-\d{4}";
            return Regex.IsMatch(valor, pattern);

        }

        public Placa(string placa)
        {
            //validação aqui!
            if (!PlacaValida(placa))
            {
                throw new ArgumentException("Placa inválida!");
            }
            Valor = placa;
        }
    }

    public enum Cor
    {
        Azul,
        Branco,
        Preto,
        Amarelo,
        Verde,
        Vermelho,
        Prata
    }

    public enum Marca
    {
        Volkswagen,
        Renault,
        Citroen,
        Fiat,
        Chevrolet,
        JAC,
        Toyota,
        Honda,
    }

    public class Modelo
    {
        public string Nome { get; private set; }
        public Marca Marca { get; private set; }

        private Modelo(string nome, Marca marca)
        {
            Nome = nome;
            Marca = marca;
        }

        public override bool Equals(object obj)
        {
            if (obj is Modelo)
            {
                var outro = (Modelo)obj;
                return this.Nome.Equals(outro.Nome) && this.Marca.Equals(outro.Marca);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 19382 + this.Nome.GetHashCode() + this.Marca.GetHashCode();
        }

        public static IEnumerable<Modelo> Modelos
        {
            get
            {
                var conjunto = new HashSet<Modelo>
                {
                    Sandero,
                    Fusca,
                    Etios,
                    Duster,
                    Uno,
                    Palio,
                };
                return conjunto;
            }
        }

        public static Modelo Sandero
        {
            get { return new Modelo("Sandero", Marca.Renault); }
        }

        public static Modelo Fusca
        {
            get { return new Modelo("Fusca", Marca.Volkswagen); }
        }

        public static Modelo Etios
        {
            get { return new Modelo("Etios", Marca.Toyota); }
        }

        public static Modelo Duster
        {
            get { return new Modelo("Duster", Marca.Renault); }
        }

        public static Modelo Uno
        {
            get { return new Modelo("Uno", Marca.Fiat); }
        }

        public static Modelo Palio
        {
            get { return new Modelo("Palio", Marca.Fiat); }
        }

    }

    public class Pessoa
    {
        public string Nome { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
    }

    public class Carro
    {
        public Placa Placa { get; set; }
        public int Ano { get; set; }
        public Modelo Modelo { get; set; }
        public Pessoa Proprietario { get; set; }
        public Cor Cor { get; set; }

        public override string ToString()
        {
            return $"Carro placa {Placa.Valor}, modelo {Modelo.Nome}, marca {Modelo.Marca}, cor {Cor}, ano {Ano} e proprietário {Proprietario.Nome}";
        }
    }
}
