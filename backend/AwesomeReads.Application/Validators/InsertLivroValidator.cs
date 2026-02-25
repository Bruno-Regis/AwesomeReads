using AwesomeReads.Application.Commands.LivrosCommands.InsertLivros;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeReads.Application.Validators
{
    public class InsertLivroValidator : AbstractValidator<InsertLivrosCommand>
    {
        public InsertLivroValidator() 
        { 
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("O título é obrigatório.")
                .MaximumLength(200).WithMessage("O título deve ter no máximo 200 caracteres.");
            RuleFor(x => x.Descricao)
                .MaximumLength(1000).WithMessage("A descrição deve ter no máximo 1000 caracteres.");
            RuleFor(x => x.ISBN)
                .NotEmpty().WithMessage("O ISBN é obrigatório.")
                .MaximumLength(20).WithMessage("O ISBN deve ter no máximo 20 caracteres.");
            RuleFor(x => x.Autor)
                .NotEmpty().WithMessage("O autor é obrigatório.")
                .MaximumLength(100).WithMessage("O autor deve ter no máximo 100 caracteres.");
            RuleFor(x => x.Editora)
                .NotEmpty().WithMessage("A editora é obrigatória.")
                .MaximumLength(100).WithMessage("A editora deve ter no máximo 100 caracteres.");   
            RuleFor(x => x.AnoDePublicacao)
                .InclusiveBetween(1450, DateTime.Now.Year).WithMessage($"O ano de publicação deve ser entre 1450 e {DateTime.Now.Year}.");
            RuleFor(x => x.QuantidadeDePaginas)
                .GreaterThan(0).WithMessage("A quantidade de páginas deve ser maior que zero.");
            RuleFor(x => x.Genero)
                .NotEmpty().WithMessage("O gênero é obrigatório.")
                .IsInEnum().WithMessage("O gênero deve ser um valor válido do enum GeneroLivroEnum.");
        }
    }
}
