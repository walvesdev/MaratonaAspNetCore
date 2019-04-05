using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaratonaAspNetCore.Models.Model
{
    public class PermissaoUsuario : Entidade
    {
        public string NivelAcesso { get; set; }
        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
