namespace Caelum.Fn13.Generics
{
    internal class Gerente : Funcionario
    {
        private static double bonusPadrao = 0.02;

        public Gerente(double salario) : base(salario)
        {
            Bonus = Gerente.bonusPadrao;
        }
    }
}