using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Fn13.Object
{
    public class Autor
    {
        public int id { get; set; }
        public string Nome { get; set; }
    }

    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public Autor Autor { get; set; }

        public Livro(string titulo, string autor)
        {
            Titulo = titulo;
            Autor = new Autor { Nome = autor };
        }
    }

    public static class LivroExtensions
    {
        public static string ParaTexto(this Livro livro)
        {
            return $"{livro.Id} {livro.Titulo} - {livro.Autor}";
        }
    }

    public class Biblioteca
    {
        static void Main()
        {
            var livro = new Livro
            (
                titulo: "It, a Coisa", 
                autor: "Stephen King"
            );
            System.Console.WriteLine(livro.ParaTexto());
        }
    }

}
