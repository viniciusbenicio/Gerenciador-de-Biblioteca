using GerenciadorLivro.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Commands.UsuarioCQRS.UpdateUsuario
{
    public class UpdateUsuarioCommandHandler : IRequestHandler<UpdateUsuarioCommand, int>
    {
        private readonly IUsuarioRepository _repository;
        public UpdateUsuarioCommandHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _repository.GetByIdAsync(request.Id);
            usuario.Atualizar(request.Nome, request.Email);

            _repository.Update(usuario);

            return usuario.Id;
        }
    }
}
