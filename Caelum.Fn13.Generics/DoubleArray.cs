using System;

namespace Caelum.Fn13.Generics
{
    internal class DoubleArray
    {
        private int indice;
        private double[] array = new double[100];

        internal void Add(double num)
        {
            array[indice] = num;
            indice++;
        }
    }
}