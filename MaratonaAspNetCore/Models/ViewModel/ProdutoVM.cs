using MaratonaAspNetCore.Models.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaratonaAspNetCore.Models.ViewModel
{
    public class ProdutoVM : Entidade
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int TipoProdutoId { get; set; }
        public TipoProduto Tipo { get; set; }
        public string Descricao { get; set; }
        public List<SelectListItem> ListaTipo { get; set; }
    }
}
