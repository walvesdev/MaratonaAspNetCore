using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaratonaAspNetCore.Models
{
    public class TipoProduto : Entidade
    {
        public string Nome { get; set; }
        public List<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
