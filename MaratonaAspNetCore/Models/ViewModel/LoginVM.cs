using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaratonaAspNetCore.Models.ViewModel
{
    public class LoginVM
    {
        public string NomeLogin { get; set; }
        public string Senha { get; set; }
        public bool Lembrar { get; set; }
        public string ReturnUrl { get; set; }
    }
}
