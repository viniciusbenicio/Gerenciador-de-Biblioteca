using MediatR;
using System;

namespace GerenciadorLivro.Application.Commands.EmprestimoCQRS.CreateEmprestimo
{
    public class CreateEmprestimoCommand : IRequest<int>
    {
        public int UsuarioId { get; set; }
        public int LivroId { get; set; }
        public int PrazoDias { get; set; }  
    }
}
