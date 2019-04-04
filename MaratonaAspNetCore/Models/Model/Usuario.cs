using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaratonaAspNetCore.Models.Model
{
    public class Usuario :Entidade
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string NomeLogin { get; set; }
        public string Permissao { get; set; }
        public string Senha { get; set; }
    }
}
