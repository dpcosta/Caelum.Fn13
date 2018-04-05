namespace Caelum.Fn13.Generics
{
    //repare que essa classe, além de generics, usa restrições
    //ou seja, essa classe só aceita tipos que herdam de Funcionario
    internal class Bonificacao<T> where T : Funcionario
    {
        public double Calcula(T funcionario)
        {
            return funcionario.Bonus * funcionario.Salario;
        }

        //uma coisa que podemos fazer é retornar o próprio objeto em um método
        public T Anuenio(T funcionario)
        {
            //funcionario.Salario = funcionario.Salario * 0.01;
            return funcionario;
        }
    }

    //compare com essa classe, que usa a hierarquia de funcionário para resolver o problema
    internal class BonificacaoFuncionario
    {
        public double Calcula(Funcionario f)
        {
            return f.Bonus * f.Salario;
        }

        public Funcionario Anuenio(Funcionario f)
        {
            return f;
        }
    }
}