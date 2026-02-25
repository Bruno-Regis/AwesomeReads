
using AwesomeReads.Application.Commands.UsersCommands.InsertUser;
using FluentValidation;

namespace AwesomeReads.Application.Validators
{
    public class InsertUsuarioValidator : AbstractValidator<InsertUsuariosCommand>
    {
        public InsertUsuarioValidator()
        { 
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("O email deve ser válido.")
                .MaximumLength(100).WithMessage("O email deve ter no máximo 100 caracteres.");
            RuleFor(x => x.Senha)
                .NotEmpty().WithMessage("A senha é obrigatória.")
                .MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caracteres.")
                .MaximumLength(23).WithMessage("A senha deve ter no máximo 23 caracteres.");
        }
    }
}
