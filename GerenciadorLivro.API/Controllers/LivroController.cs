using GerenciadorLivro.Application.Commands.LivroCQRS.CreateLivro;
using GerenciadorLivro.Application.Commands.LivroCQRS.RemoveLivro;
using GerenciadorLivro.Application.Commands.LivroCQRS.UpdateLivro;
using GerenciadorLivro.Application.Queries.LivroQueries.GetAllLivros;
using GerenciadorLivro.Application.Queries.LivroQueries.GetByIdLivro;
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
            var allLivros = await _mediator.Send(getAllLivros);

            return Ok(allLivros);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateLivroCommand command)
        {
            await _mediator.Send(command);

            return Ok("Atualizado com sucesso.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromBody] RemoveLivroCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(id);
        }

        //[HttpPost("emprestimo")]
        //public async Task<IActionResult> Emprestimo([FromBody] CreateEmprestimoCommand command)
        //{
        //    await _mediator.Send(command);
        //    return Ok("Emprestimo realizado com sucesso.");
        //}

        //[HttpPut("devolver/{id}")]
        //public async Task<IActionResult> DevolverLivro()
        //{
        //    return Ok();
        //}
    }
}
