using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Fn13.Enumerados
{

    enum AvaliacaoIMC
    {
        Normal,
        Sobrepeso,
        Obesidade
    }

    public struct DBInt
    {
        // The Null member represents an unknown DBInt value.

        public static readonly DBInt Null = new DBInt();

        // When the defined field is true, this DBInt represents a known value
        // which is stored in the value field. When the defined field is false,
        // this DBInt represents an unknown value, and the value field is 0.

        int value;
        bool defined;

        // Private instance constructor. Creates a DBInt with a known value.

        DBInt(int value)
        {
            this.value = value;
            this.defined = true;
        }
    }

    class Program
    {
        static void Main()
        {
            DBInt value = new DBInt();
            
        }
    }
}
