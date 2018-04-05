using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Fn13.Object
{

    class Pessoa
    {
        public string Nome { get; private set; }
        public int Idade { get; private set; }

        public Pessoa(string nome)
        {
            Nome = nome;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is Pessoa)
            {
                var outro = (Pessoa)obj;
                return this.Nome == outro.Nome;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 285249808 + Nome.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }


    class Program
    {
        static void Main()
        {
            var p = new Pessoa("Fulano de Tal");
            //como ele consegue compilar? Pessoa não é conhecido pelo WriteLine!!
            Console.WriteLine(p);


            var p2 = new Pessoa("Sicrano de Tal");
            Console.WriteLine(p2);

            var p3 = new Pessoa("Fulano de Tal");
            Console.WriteLine(p3);


            Console.WriteLine("São iguais? " + (p == p3));
            Console.WriteLine("São iguais? " + (p.Equals(p3)));

            p.Equals(null);



        }
    }
}
