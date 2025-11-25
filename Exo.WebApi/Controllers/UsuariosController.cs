using Exo.WebApi.Models;
using Exo.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Exo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuariosController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_usuarioRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Usuario? usuario = _usuarioRepository.BuscarPorId(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            _usuarioRepository.Cadastrar(usuario);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuario usuario)
        {
            Usuario? usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            if (usuarioBuscado == null)
            {
                return NotFound();
            }

            _usuarioRepository.Atualizar(id, usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            Usuario? usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            if (usuarioBuscado == null)
            {
                return NotFound();
            }

            _usuarioRepository.Deletar(id);
            return NoContent();
        }
    }
}

