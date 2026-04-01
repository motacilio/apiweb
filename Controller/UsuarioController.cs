using apiweb.Dto;
using apiweb.Interfaces;
using apiweb.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace apiweb.Controller
{
    [ApiController]
    [Route("api/v1/usuario")]
    public class UsuarioController : ControllerBase
    {
        public readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException();    
        }

        [HttpPost]
        public IActionResult Add(CriarUsuarioDTO usuarioCriado)
        {
            var novoUsuario = usuarioCriado.ToUsuarioEntity();
           _usuarioRepository.AdicionarUsuarioAsync(novoUsuario);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _usuarioRepository.ListarUsuariosAsync();
            var usuariosDTO = usuarios.Select(s => s.ToUsuarioDTO());
            return Ok(usuariosDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioById([FromRoute] int id)
        {
            var usuario = (await _usuarioRepository.AcharUsuarioPorIdAsync(id)).ToUsuarioDTO();
            if(usuario == null){
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarUsuario([FromRoute] int id, [FromBody] UsuarioDTO usuarioAtualizado)
        {
           var usuario = (await _usuarioRepository.AtualizarUsuarioAsync(id, usuarioAtualizado)).ToUsuarioDTO();

           if(usuario == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarUsuario([FromRoute] int id)
        {
            var usuarioDeletado =  (await _usuarioRepository.DeletarUsuarioAsync(id)).ToUsuarioDTO();
            if(usuarioDeletado == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}