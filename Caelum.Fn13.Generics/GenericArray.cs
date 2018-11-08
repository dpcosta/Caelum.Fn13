namespace Caelum.Fn13.Generics
{
    internal class GenericArray<T>
    {
        private int capacidade = 100;
        private int indice;
        private T[] array;

        public GenericArray()
        {
            array = new T[capacidade];
        }

        private void AumentaArray()
        {
            capacidade *= 2;
            var arrayAux = new T[capacidade];
            for(int i = 0; i <= array.Length; i ++)
            {
                arrayAux[i] = array[i];
            }
            array = arrayAux;
        }

        public void Add(T item)
        {
            if (indice >= capacidade)
            {
                AumentaArray();
            }
            array[indice] = item;
            indice++;
        }
    }
}