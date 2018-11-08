using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Fn13.Object
{
    internal class Produto
    {
        public int Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Categoria { get; protected set; }
        public decimal PrecoUnitario { get; protected set; }
    }

    internal class ProdutoVirtual : Produto
    {
        private bool _disponivel;

        public ProdutoVirtual()
        {
            _disponivel = false;
        }

        public bool EstaDisponivel()
        {
            return _disponivel;
        }
    }
}
