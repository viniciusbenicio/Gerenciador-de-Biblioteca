using GerenciadorLivro.Application.Commands.CreateUsuario;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GerenciadorLivro.API.Controllers
{
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUsuarioCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
    }
}
