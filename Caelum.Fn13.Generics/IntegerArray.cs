using System;

namespace Caelum.Fn13.Generics
{
    internal class IntegerArray
    {
        private int capacidade = 100;
        private int indice;
        private int[] array;

        public IntegerArray()
        {
            array = new int[capacidade];
        }

        internal void Add(int num)
        {
            if (indice >= capacidade)
            {
                capacidade *= 2;
                array = new int[capacidade];
            }
            array[indice] = num;
            indice++;
        }
    }
}