using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Fn13.Collections
{
    public interface ISerializador<T>
    {
        string Extensao { get; }
        string Serialize(T obj);
    }
}
