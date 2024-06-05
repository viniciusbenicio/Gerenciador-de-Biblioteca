using GerenciadorLivro.Core.Entites;
using GerenciadorLivro.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GerenciadorLivro.API.Controllers
{
    [Route("api/livros")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _repository;
        public LivroController(ILivroRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
           var livros = await _repository.GetAllAsync();

            return Ok(livros);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok();
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Livro model)
        {
            var livro = new Livro("Teste", "Teste", "Teste", 2024);

            await _repository.AddAsync(livro);
            
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
