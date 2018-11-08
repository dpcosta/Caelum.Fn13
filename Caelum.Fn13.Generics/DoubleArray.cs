using System;

namespace Caelum.Fn13.Generics
{
    internal class DoubleArray
    {
        private int indice;
        private int capacidade = 100;
        private double[] array;

        public DoubleArray()
        {
            array = new double[capacidade];
        }

        internal void Add(double num)
        {
            if (indice >= capacidade)
            {
                capacidade *= 2;
                array = new double[capacidade];
            }
            array[indice] = num;
            indice++;
        }
    }
}