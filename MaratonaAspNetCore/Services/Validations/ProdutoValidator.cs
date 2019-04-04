using FluentValidation;
using MaratonaAspNetCore.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBaseMVC.Model.Validations
{

    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("Digite o nome do Produto!")
                .Length(0, 100).WithMessage("O nome pode conter no maximo 100 caracteres");
            RuleFor(p => p.TipoProdutoId).NotEmpty().WithMessage("Selecione o Tipo do Produto");
            RuleFor(p => p.Descricao).NotEmpty().WithMessage("Informe a descrição do produto!").Length(1, 300).WithMessage("Quantidade maximade caracteres: 300");
            RuleFor(P => P.Valor).NotEmpty().WithMessage("Informe o valor do Produto!");
        }
    }
}