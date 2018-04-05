using System.Text;

namespace Caelum.Fn13.Collections
{
    internal class CSVSerializer : ISerializador<Carro>
    {
        public string Extensao => "csv";

        public string Serialize(Carro carro)
        {
            return $"{carro.Placa.Valor};{carro.Modelo.Nome};{carro.Modelo.Marca};{carro.Cor};{carro.Ano};{carro.Proprietario.Nome}";
        }
    }
}