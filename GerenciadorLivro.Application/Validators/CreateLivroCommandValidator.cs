using FluentValidation;
using GerenciadorLivro.Application.Commands.LivroCQRS.CreateLivro;

namespace GerenciadorLivro.Application.Validators
{
    public class CreateLivroCommandValidator : AbstractValidator<CreateLivroCommand>
    {
        public CreateLivroCommandValidator()
        {
            RuleFor(l => l.Titulo)
                .MinimumLength(3)
                .WithMessage("Informe um Título que contém mais de 3 caracteres");
        }
    }
}
