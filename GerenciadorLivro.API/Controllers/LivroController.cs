using GerenciadorLivro.Application.Commands.CreateLivro;
using GerenciadorLivro.Application.Queries.GetAllLivros;
using GerenciadorLivro.Application.Queries.GetByIdLivro;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GerenciadorLivro.API.Controllers
{
    [Route("api/livros")]
    public class LivroController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LivroController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllLivros = new GetAllLivrosQuery(query);
            await _mediator.Send(getAllLivros);

            return Ok(getAllLivros);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdLivroQuery(id);

            var livro = await _mediator.Send(query);

            return Ok(livro);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLivroCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPost("emprestimo/{id}")]
        public async Task<IActionResult> Emprestimo()
        {
            return Ok();
        }

        [HttpPut("devolver/{id}")]
        public async Task<IActionResult> DevolverLivro()
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }

    }
}
