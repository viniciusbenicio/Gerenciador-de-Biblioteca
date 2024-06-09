using GerenciadorLivro.Core.Entites;
using GerenciadorLivro.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Commands.UsuarioCQRS.CreateUsuario
{
    public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, int>
    {
        private readonly IUsuarioRepository _repository;
        public CreateUsuarioCommandHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = new Usuario(request.Nome, request.Email);

            await _repository.AddAsync(usuario);

            return usuario.Id;
        }
    }
}
