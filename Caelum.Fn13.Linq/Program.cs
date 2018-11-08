using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Fn13.Linq
{
    class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public double PrecoUnitario { get; set; }
    }

    delegate bool CondicaoCategoriaProduto(Produto prod, string categoria);
    delegate void AcaoComProduto(Produto prod);

    class Program
    {
        private static double precoTotal;

        static void Main(string[] args)
        {
            //seja a seguinte coleção de produtos:
            var produtos = new List<Produto>
            {
                        new Produto { Id = 1, Descricao = "Laranja", Categoria = "Hortifruti", PrecoUnitario = 0.99 },
                        new Produto { Id = 2, Descricao = "Banana", Categoria = "Hortifruti", PrecoUnitario = 1.99 },
                        new Produto { Id = 3, Descricao = "Maçã", Categoria = "Hortifruti", PrecoUnitario = 2.99 },
                        new Produto { Id = 4, Descricao = "Abacaxi", Categoria = "Hortifruti", PrecoUnitario = 3.99 },
                        new Produto { Id = 5, Descricao = "Morango", Categoria = "Hortifruti", PrecoUnitario = 4.99 },

                        new Produto { Id = 6, Descricao = "Detergente", Categoria = "Limpeza", PrecoUnitario = 5.99 },
                        new Produto { Id = 7, Descricao = "Água Sanitária", Categoria = "Limpeza", PrecoUnitario = 6.99 },
                        new Produto { Id = 8, Descricao = "Detergente", Categoria = "Limpeza", PrecoUnitario = 7.99 },

                        new Produto { Id = 9, Descricao = "Presunto", Categoria = "Frios", PrecoUnitario = 8.99 },
                        new Produto { Id = 10, Descricao = "Mortadela", Categoria = "Frios", PrecoUnitario = 9.99 },
                        new Produto { Id = 11, Descricao = "Muzzarela", Categoria = "Frios", PrecoUnitario = 10.99 },

                        new Produto { Id = 12, Descricao = "Picanha", Categoria = "Carnes", PrecoUnitario = 11.99 },
                        new Produto { Id = 13, Descricao = "Patinho", Categoria = "Carnes", PrecoUnitario = 12.99 },
                        new Produto { Id = 14, Descricao = "Frango", Categoria = "Carnes", PrecoUnitario = 13.99 },
                        new Produto { Id = 15, Descricao = "Calabresa", Categoria = "Carnes", PrecoUnitario = 14.99 },
                        new Produto { Id = 16, Descricao = "Peixe", Categoria = "Carnes", PrecoUnitario = 15.99 },
            };


            //1- listar todos os produtos
            foreach (var prod in produtos)
            {
                Console.WriteLine($"{prod.Descricao} - {prod.Categoria} : R$ {prod.PrecoUnitario:n2}");
            }

            //2- listar as carnes
            foreach (var prod in produtos)
            {
                if (prod.Categoria == "Carnes")
                {
                    Console.WriteLine($"{prod.Descricao} - {prod.Categoria} : R$ {prod.PrecoUnitario:n2}");
                }
            }

            //código duplicado de impressão >> extrair para um método
            foreach (var prod in produtos)
            {
                if (prod.Categoria == "Carnes")
                {
                    ImprimirProduto(prod);
                }
            }

            //3- listar os hortifrutis
            foreach (var prod in produtos)
            {
                if (prod.Categoria == "Hortifruti")
                {
                    ImprimirProduto(prod);
                }
            }

            //código da condição está duplicado >> extrair
            foreach (var prod in produtos)
            {
                if (CategoriaEh(prod, "Hortifruti"))
                {
                    ImprimirProduto(prod);
                }
            }

            //4- listar produtos cujo preço é maior que 5 reais
            foreach (var prod in produtos)
            {
                if (PrecoEhMaiorQue(prod, valor: 5.0))
                {
                    ImprimirProduto(prod);
                }
            }

            //5- listar frios e limpeza
            foreach (var prod in produtos)
            {
                if(CategoriaEh(prod, "Frios") || CategoriaEh(prod, "Limpeza"))
                {
                    ImprimirProduto(prod);
                }
            }

            //o que mais está duplicado? a estrutura! extrair...
            Func<Produto, string, bool> condicao = CategoriaEh;
            Action<Produto> acao = ImprimirProduto;
            foreach (var prod in produtos)
            {
                if (condicao(prod,"Carnes"))
                {
                    acao(prod);
                }
            }

            //Func e Action são delegates. Tipos para representar métodos!
            //podemos criar nossos próprios delegates. Olha:
            CondicaoCategoriaProduto condCateg = CategoriaEh;
            AcaoComProduto imprime = ImprimirProduto;

            //objetivo é usar esses tipos como argumentos de outros métodos
            //por ex., posso extrair também o código que percorre a lista
            //e colocar como argumentos os dois delegates que criamos...

            //para listar os frios...
            PercorreCategoriaDeProdutos(produtos, condCateg, "Frios", imprime);

            //para listar as carnes...
            PercorreCategoriaDeProdutos(produtos, condCateg, "Carnes", imprime);

            //para listas os hortifrutis...
            PercorreCategoriaDeProdutos(produtos, condCateg, "Hortifruti", imprime);

            //posso até usar essa sintaxe aqui...
            PercorreCategoriaDeProdutos(
                produtos,
                delegate (Produto prod, string categ) { return prod.Categoria == categ; },
                "Carnes",
                imprime);

            //são chamados métodos anônimos. Objetivo é não precisar ficar escrevendo
            //métodos apenas para passar como argumento

            //e repara que desse jeito posso simplificar meu método Percorre
            //criando um método mais genérico
            PercorreProdutosComCondicao(
                produtos,
                condicao: delegate (Produto prod) { return prod.Categoria == "Hortifruti"; },
                acao: imprime
            );

            //esse novo método me permite generalizar ainda mais a condição
            //por exemplo usando mais de uma condição
            PercorreProdutosComCondicao(
                produtos: produtos,
                condicao: delegate (Produto prod) {
                    return prod.Categoria == "Hortifruti" || prod.Categoria == "Frios";
                },
                acao: imprime
            );

            //o .NET criou um delegate para representar qualquer método que retorne
            //verdadeiro/falso para um argumento do tipo genérico T
            //então nem precisaríamos criar um delegate, bastaria usar Pred<Produto> 
            //como argumento do método PercorreProdutosComCondicao

            //e até condições com campos diferentes. Uhú!
            PercorreProdutosComCondicao(
                produtos: produtos,
                condicao: delegate (Produto prod) {
                    return prod.PrecoUnitario > 5.0;
                },
                acao: imprime
            );

            //delegates são foda! Olha oq posso fazer também...

            AcaoComProduto maisDeUmaAcao = ImprimirProduto;
            maisDeUmaAcao += SomaPrecoUnitario; 
            //posso incluir mais de uma ação a ser executada! Que isso, bolei!

            PercorreProdutosComCondicao(
                produtos: produtos,
                condicao: delegate (Produto prod) {
                    return prod.PrecoUnitario > 5.0;
                },
                acao: maisDeUmaAcao
            );
            Console.WriteLine($"Preço total é {precoTotal}");



            //repara que com essa nova sintaxe eu não preciso nem mais criar
            //aqueles delegates lá em cima. Bastava eu chamá-los aqui.
            //O único problema que vejo é na qtde de código q escrevo para isso.
            //Olha a confusão: destacar "delegate", tipo do argumento, "return", abre/fecha chaves...
            //chatooo!

            //daí o pessoal caridoso do .NET resolveu dar mais um help
            //e implementou as expressões lambda

            //elas são assim:
            PercorreProdutosComCondicao(
                produtos: produtos,
                condicao: prod => prod.PrecoUnitario > 5.0,
                acao: maisDeUmaAcao
            );
            Console.WriteLine($"Preço total é {precoTotal}");

            //posso fazer o mesmo para a ação...
            PercorreProdutosComCondicao(
                produtos: produtos,
                condicao: prod => prod.PrecoUnitario > 5.0,
                acao: prod => Console.WriteLine($"{prod.Descricao} - {prod.Categoria} : R$ {prod.PrecoUnitario:n2}")
            );
            Console.WriteLine($"Preço total é {precoTotal}");

            //essa notação lado esquerdo => lado direito é chamada de expressão lambda
            //o lado esquerdo representa os argumentos que serão passados para 
            //o lado direito executar

            //ótimo! já sabemos delegates e expressões lambda
            //agora falta mais um bloco para eu apresentar o LINQ

            //métodos de extensão

            //ainda existem outras coisas a fazer: ordenar, mapear, reduzir
            //biblioteca com métodos de extensão para tudo isso: LINQ


            //6- ordenar os produtos por preço
            //6.1 - criar um comparer de produto
            //6.2 - chamar o sort com um objeto desse tipo

        }

        private static void SomaPrecoUnitario(Produto prod)
        {
            precoTotal += prod.PrecoUnitario;
        }

        private static void PercorreProdutosComCondicao(
            List<Produto> produtos, 
            Func<Produto, bool> condicao, 
            //ou Predicate<Produto> condicao
            AcaoComProduto acao)
        {
            foreach (var prod in produtos)
            {
                if (condicao(prod))
                {
                    acao(prod);
                }
            }
        }

        private static void PercorreCategoriaDeProdutos(
            List<Produto> produtos, 
            CondicaoCategoriaProduto condicao,
            string categoria,
            AcaoComProduto acao)
        {
            foreach (var prod in produtos)
            {
                if (condicao(prod, categoria))
                {
                    acao(prod);
                }
            }
        }

        private static bool PrecoEhMaiorQue(Produto prod, double valor)
        {
            return prod.PrecoUnitario > valor;
        }

        private static bool CategoriaEh(Produto prod, string categ)
        {
            return prod.Categoria == categ;
        }

        private static void ImprimirProduto(Produto prod)
        {
            Console.WriteLine($"{prod.Descricao} - {prod.Categoria} : R$ {prod.PrecoUnitario:n2}");
        }
    }
}
