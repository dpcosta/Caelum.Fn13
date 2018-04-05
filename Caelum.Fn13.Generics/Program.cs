using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Fn13.Generics
{
    class Program
    {
        static void Main()
        {
            //para trabalhar com diversos valores agrupados podemos usar arrays
            var array = new int[] { 1, 2, 3, 4 };

            //problema é que ficamos responsáveis por aumentar sua capacidade,
            //comprimir, incluir no meio, remover, etc.

            //.NET nos deu um tipo para encapsular o comportamento de um array: ArrayList
            var objetos = new ArrayList();
            objetos.Add(1);
            objetos.Add(2);
            objetos.Add(3);

            //contudo, posso incluir qualquer tipo de objeto nessa "lista"
            objetos.Add("quatro"); //isso faz sentido pra você? Pra mim não!

            //o que fazer para restringir para um tipo específico?

            //Olha a declaração do método Add() em ArrayList (F12 no método...)
            //Como argumento de entrada, ele espera um object
            //Se ArrayList é uma lista de Object, será que existe uma lista de inteiros?
            //Infelizmente não:-(
            //Então eu mesmo vou criar minha lista de inteiros!
            var inteiros = new IntegerArray();
            inteiros.Add(num: 1);
            inteiros.Add(2);
            inteiros.Add(3);

            //mas e se eu quiser uma lista de double?
            //faço outro tipo!
            var doubles = new DoubleArray();
            doubles.Add(num: 1.2);
            doubles.Add(2.4);

            //e, se houver um tipo Animal, eu quiser criar uma lista de Animal?
            //vou ter que criar outro tipo! Chaaaato e mais: repetitivo! 
            //Repara que no código das duas listas (IntegerArray e DoubleArray) sua única mudança
            //é justamente o tipo ao qual queremos restringir a lista

            //C# resolveu isso pra gente! Criou a possibilidade de termos tipos genéricos
            //isto é, tipos para qualquer tipo, desde que o tipo seja informado por parâmetro
            //vamos ver como fica!

            //por exemplo para usar o tipo genérico para criar uma lista de inteiros eu faço
            var lista = new GenericArray<int>();
            lista.Add(1);
            lista.Add(45);

            //e se eu quiser usar o MESMO TIPO para criar uma lista de doubles eu faço
            var lista2 = new GenericArray<double>();
            lista2.Add(1.2);
            lista2.Add(43.2);

            //NÃO É LINDO ISSO??!

            //só que a gente não precisava ter criado esse tipo GenericArray
            //.NET já tem uma API inteira relacionada a coleções
            //e todos os tipos (a maioria vai!) usam generics
            //que está no namespace System.Collections.Generics

            //Recapitulando, sempre que você:
            //1- criar um tipo A que possui o MESMO comportamento para DIFERENTES tipos
            //2- quiser RESTRINGIR que tipo o consumidor do tipo A vai usar na sua construção
            //Então, considere usar GENERICS

            //olha um exemplo de bonificação salarial escrito com generics
            var g1 = new Gerente(4200.00);
            var g2 = new Gerente(6750.00);
            var e1 = new Engenheiro(3800.00);

            var bonusGerente = new Bonificacao<Gerente>();
            Console.WriteLine(bonusGerente.Calcula(g1));
            Console.WriteLine(bonusGerente.Calcula(g2));

            var bonusEngenheiro = new Bonificacao<Engenheiro>();
            Console.WriteLine(bonusEngenheiro.Calcula(e1));

            //você pode questionar esse exemplo dizendo poxa, Daniel, era só ter colocado 
            //o cálculo de bonificação lá na classe Funcionario
            //mas e se a hierarquia de funcionário não estivesse sob seu controle?
            //não posso tocar em uma linha de código de gerente, funcionário ou engenheiro!
            //nesse caso, generics é uma boa! Não é a única alternativa, veja aqui

            //compare o consumo de um generics com o objeto seguinte
            var outroTipoBonus = new BonificacaoFuncionario();
            
            //essa classe aceita qualquer funcionário...
            Console.WriteLine(outroTipoBonus.Calcula(g1));
            Console.WriteLine(outroTipoBonus.Calcula(g2));
            Console.WriteLine(outroTipoBonus.Calcula(e1));

            //...já bonusGerente só aceita gerentes pq eu criei essa variável assim
            //...e o mesmo acontece com bonusEngenheiro, que só aceita engenheiros

            var obj = bonusGerente.Anuenio(g1);
            var obj2 = outroTipoBonus.Anuenio(g1);

            //generics são muito utilizados em padrões de projeto, porque a solução é encapsulada
            //em um tipo, enquanto o objeto de c
            //um outro exemplo muito comum é o generic DAO, mas isso é assunto pra outro dia!
        }
    }
}
