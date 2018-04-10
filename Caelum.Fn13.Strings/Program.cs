using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Fn13.Strings
{
    class Program
    {
        class Pessoa
        {
            public string Nome { get; set; }
        }

        //decora uma pessoa tornando-a imutável!
        class PessoaImutavelDecorator : Pessoa
        {
            private string _nome;

            //repare o uso da palavra reservada NEW para indicar que estamos 
            //intencionalmente escondendo a implementação da propriedade Nome no pai
            public new string Nome
            {
                get { return (string)_nome.Clone(); }
                //set { }
            }
            public PessoaImutavelDecorator(Pessoa pessoa)
            {
                _nome = pessoa.Nome;
            }

        }

        static void Main()
        {
            //string é imutável. Porquê? Porque são muuuuuuuito usadas nos programas
            //literalmente vc pode ter milhões de objetos do tipo string em seu app
            //e é necessário proteger os dados desses objetos de acessos de outros códigos
            var mensagem = "Olá, mundo!";
            var pessoa = new Pessoa { Nome = "Fulano" };

            //qual valor será impresso?
            Console.WriteLine("\nVerificando imutabilidade da string 'mensagem'");
            Console.WriteLine(mensagem);
            MudaChamativo(mensagem);
            Console.WriteLine(mensagem);

            //e aqui, qual valor será impresso?
            Console.WriteLine("\nVerificando imutabilidade do objeto 'pessoa'");
            Console.WriteLine(pessoa.Nome);
            MudaPessoa(pessoa);
            Console.WriteLine(pessoa.Nome);


            //em um objeto imutável, há garantia de que ele (seus dados) não vai mudar
            //ou seja, posso passá-lo pra qualquer código de terceiro com ctz de q vai ficar intacto

            //isso é legal! Mas como faço para tornar Pessoa imutável também?
            //como vc protege sua original da certidão de nascimento?
            //fazendo uma cópia, certo? Uma xerox!
            Console.WriteLine("\nVerificando imutabilidade do objeto 'pessoaImutavel'");
            var pessoaImutavel = new PessoaImutavelDecorator(pessoa);
            Console.WriteLine(pessoaImutavel.Nome);
            MudaPessoa(pessoaImutavel);
            Console.WriteLine(pessoaImutavel.Nome);

            //observação: nesse exemplo eu usei um padrão de projeto chamado Decorator


            //igualdade entre strings
            Console.WriteLine("\nVerificando igualdade entre duas strings:");
            var umaString = "ABCDE";
            var outraString = new String(new char[] { 'A', 'B', 'C', 'D', 'E' });
            Console.WriteLine(umaString);
            Console.WriteLine(outraString);
            Console.WriteLine("São iguais? Resultado usando '==': {0}", umaString == outraString);
            Console.WriteLine("São iguais? Resultado usando Equals: {0}", umaString == outraString);


        }


        static void MudaChamativo(string mensagem)
        {
            mensagem = "Olá, galera!";
        }

        static void MudaPessoa(Pessoa pessoa)
        {
            pessoa.Nome = "Sicrano";
        }
    }
}
