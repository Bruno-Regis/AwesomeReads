using AwesomeReads.Application.Commands.AvaliacoesCommands.InsertAvaliacoes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeReads.Application.Validators
{
    public class InsertAvaliacaoValidator : AbstractValidator<InsertAvaliacoesCommand>
    {
        public InsertAvaliacaoValidator() 
        { 
            RuleFor(x => x.Nota)
                .InclusiveBetween(1, 5).WithMessage("A nota deve ser entre 1 e 5.");
            RuleFor(x => x.Descricao)
                .MaximumLength(500).WithMessage("A descrição deve ter no máximo 500 caracteres.");
        }
    }
}
