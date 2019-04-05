using FluentValidation;
using MaratonaAspNetCore.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBaseMVC.Model.Validations
{

    public class PermissaoUsuarioValidator : AbstractValidator<PermissaoUsuario>
    {
        public PermissaoUsuarioValidator()
        {
            RuleFor(p => p.NivelAcesso).NotEmpty().WithMessage("Digite o nível de permissão do Usuario!").Length(50).WithMessage("Pode conter no maximo 50 caracteres");
            
        }
    }
}