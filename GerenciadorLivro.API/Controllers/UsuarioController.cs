using GerenciadorLivro.Application.Commands.CreateUsuario;
using GerenciadorLivro.Application.Commands.RemoveUsuario;
using GerenciadorLivro.Application.Commands.UpdateUsuario;
using GerenciadorLivro.Application.Queries.GetAllLivros;
using GerenciadorLivro.Application.Queries.GetAllUsuarios;
using GerenciadorLivro.Application.Queries.GetByIdUsuario;
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

        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllUsuarios = new GetAllUsuariosQuery(query);
            var allUsuarios = await _mediator.Send(getAllUsuarios);

            return Ok(allUsuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdUsuarioQuery(id);

            var usuario = await _mediator.Send(query);

            return Ok(usuario);

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUsuarioCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateUsuarioCommand command)
        {
            await _mediator.Send(command);

            return Ok("Atualizado com sucesso.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromBody] RemoveUsuarioCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(id);
        }
    }
}
