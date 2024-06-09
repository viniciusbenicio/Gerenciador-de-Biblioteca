using FluentValidation;
using GerenciadorLivro.Application.Commands.LivroCQRS.CreateLivro;

namespace GerenciadorLivro.Application.Validators
{
    public class CreateLivroCommandValidator : AbstractValidator<CreateLivroCommand>
    {
        public CreateLivroCommandValidator()
        {
            RuleFor(l => l.Titulo)
                .MinimumLength(5)
                .WithMessage("Informe um Título que contém mais de 3 caracteres")
                .MaximumLength(255)
                .WithMessage("O Título informado deve conter até 255 caracteres");
          
        }
}
}
