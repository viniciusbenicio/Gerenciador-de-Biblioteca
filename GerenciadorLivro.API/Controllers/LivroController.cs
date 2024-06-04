using GerenciadorLivro.Core.Entites;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GerenciadorLivro.API.Controllers
{
    [Route("api/livros")]
    public class LivroController : ControllerBase
    {
        public LivroController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok();
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Livro model)
        {
            return Ok(model);
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
