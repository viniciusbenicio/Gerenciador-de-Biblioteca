using MediatR;

namespace GerenciadorLivro.Application.Commands.EmprestimoCQRS.CreateEmprestimo
{
    public class CreateEmprestimoCommand : IRequest<int>
    {
        public int IdUsuario { get; set; }
        public int IdLivro { get; set; }
    }
}
