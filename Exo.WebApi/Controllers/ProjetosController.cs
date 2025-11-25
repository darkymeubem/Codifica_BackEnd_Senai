using Exo.WebApi.Models;
using Exo.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Exo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private readonly ProjetoRepository _projetoRepository;

        public ProjetosController(ProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_projetoRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Projeto? projeto = _projetoRepository.BuscarPorId(id);

            if (projeto == null)
            {
                return NotFound();
            }

            return Ok(projeto);
        }

        [HttpPost]
        public IActionResult Cadastrar(Projeto projeto)
        {
            _projetoRepository.Cadastrar(projeto);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Projeto projeto)
        {
            Projeto? projetoBuscado = _projetoRepository.BuscarPorId(id);

            if (projetoBuscado == null)
            {
                return NotFound();
            }

            _projetoRepository.Atualizar(id, projeto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            Projeto? projetoBuscado = _projetoRepository.BuscarPorId(id);

            if (projetoBuscado == null)
            {
                return NotFound();
            }

            _projetoRepository.Deletar(id);
            return NoContent();
        }
    }
}

