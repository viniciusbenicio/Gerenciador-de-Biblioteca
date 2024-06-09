using MediatR;

namespace GerenciadorLivro.Application.Commands.EmprestimoCQRS.RemoveEmprestimo
{
    public class RemoveEmprestimoCommand : IRequest<int>
    {
        public RemoveEmprestimoCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
