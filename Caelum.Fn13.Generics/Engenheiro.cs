namespace Caelum.Fn13.Generics
{
    internal class Engenheiro : Funcionario
    {
        private static double bonusPadrao = 0.01;

        public Engenheiro(double salario) : base(salario)
        {
            Bonus = Engenheiro.bonusPadrao;
        }
    }
}