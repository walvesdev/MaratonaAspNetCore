using FluentValidation;
using MaratonaAspNetCore.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBaseMVC.Model.Validations
{

    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(p => p.Nome).NotEmpty().WithMessage("Digite o nome do Usuario!").Length(0, 100).WithMessage("O nome pode conter no maximo 100 caracteres");
            RuleFor(p => p.NomeLogin).NotEmpty().WithMessage("Digite o nome de login do Usuario!").Length(50).WithMessage("O login pode conter no maximo 50 caracteres");
            RuleFor(p => p.Permissao).NotEmpty().WithMessage("Informe a permissão do usuario!").Length(50).WithMessage("A permissão pode conter no maximo 50 caracteres");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Informe Email do usuario!").Length(100).WithMessage("A permissão pode conter no maximo 100 caracteres");
            RuleFor(p => p.Senha).NotEmpty().WithMessage("Informe a permissão do usuario!").Length(15).WithMessage("A senha pode conter no maximo 15 caracteres");

        }
    }
}