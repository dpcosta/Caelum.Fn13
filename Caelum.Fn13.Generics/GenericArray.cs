namespace Caelum.Fn13.Generics
{
    internal class GenericArray<T>
    {
        private int indice;
        private T[] array = new T[100];

        public void Add(T item)
        {
            array[indice] = item;
            indice++;
        }
    }
}