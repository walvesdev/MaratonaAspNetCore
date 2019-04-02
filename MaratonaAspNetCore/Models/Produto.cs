using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaratonaAspNetCore.Models
{
    public class Produto : Entidade
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int TipoProdutoId { get; set; }
        public TipoProduto Tipo { get; set; }

    }
}
