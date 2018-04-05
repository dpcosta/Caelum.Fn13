using System;

namespace Caelum.Fn13.Generics
{
    internal class IntegerArray
    {
        private int indice;
        private int[] array = new int[100];

        internal void Add(int num)
        {
            array[indice] = num;
            indice++;
        }
    }
}