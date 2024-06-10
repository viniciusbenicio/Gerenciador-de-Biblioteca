using GerenciadorLivro.Application.Commands.EmprestimoCQRS.CreateEmprestimo;
using GerenciadorLivro.Application.Commands.EmprestimoCQRS.RemoveEmprestimo;
using GerenciadorLivro.Application.Commands.EmprestimoCQRS.UpdateEmprestimo;
using GerenciadorLivro.Application.Queries.EmprestimoQueries.GetAllEmprestimo;
using GerenciadorLivro.Application.Queries.EmprestimoQueries.GetByIdEmprestimo;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GerenciadorLivro.API.Controllers.Emprestimo
{
    [Route("api/Emprestimos")]
    [Authorize]
    public class EmprestimoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmprestimoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "admin,comum")]
        public async Task<IActionResult> Get(string query)
        {
            var getAllEmprestimos = new GetAllEmprestimoQuery(query);
            var allEmprestimos = await _mediator.Send(getAllEmprestimos);

            return Ok(allEmprestimos);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin,comum")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdEmprestimoQuery(id);

            var Emprestimo = await _mediator.Send(query);

            return Ok(Emprestimo);

        }

        [HttpPost("")]
        [Authorize(Roles = "admin,comum")]
        public async Task<IActionResult> Post([FromBody] CreateEmprestimoCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin,comum")]
        public async Task<IActionResult> Put([FromBody] UpdateEmprestimoCommand command)
        {
            await _mediator.Send(command);

            return Ok("Atualizado com sucesso.");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete([FromBody] RemoveEmprestimoCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(id);
        }
    }
}
