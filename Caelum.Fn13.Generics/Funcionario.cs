namespace Caelum.Fn13.Generics
{
    internal class Funcionario
    {
        public double Salario { get; private set; }
        public double Bonus { get; protected set; }

        public Funcionario(double salario)
        {
            Salario = salario;
        }
    }
}