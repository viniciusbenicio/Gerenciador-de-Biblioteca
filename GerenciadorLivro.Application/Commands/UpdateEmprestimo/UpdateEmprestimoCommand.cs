using GerenciadorLivro.Core.Entites;
using MediatR;
using System;

namespace GerenciadorLivro.Application.Commands.UpdateEmprestimo
{
    public class UpdateEmprestimoCommand : IRequest<int>
    {
        public UpdateEmprestimoCommand(int id)
        {

            Id = id;

        }
        public int Id { get; set; }
        public int IdLivro { get;  set; }
        public DateTime DataEmprestimo { get;  set; }
    }
}
