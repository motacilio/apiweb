using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiweb.Dto;
using apiweb.Entity;
using apiweb.Mappers;
using apiweb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

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
        public IActionResult Add(CriarUsuarioDTO createUsuario)
        {
            var novoUsuario = createUsuario.ToUsuarioEntity();
           _usuarioRepository.AdicionarUsuario(novoUsuario);
            return Ok();
           //return CreatedAtAction(nameof(GetUsuarioById), novoUsuario.id);
        }

        [HttpGet]
        public IActionResult GetUsuarios()
        {
            var usuarios = _usuarioRepository.ListarUsuarios()
            .Select(s => s.ToUsuarioDTO());
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetUsuarioById([FromRoute] int id)
        {
            var usuario = _usuarioRepository.AcharUsuarioPorId(id).ToUsuarioDTO();

            if(usuario == null){
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarUsuario([FromRoute] int id, [FromBody] UsuarioDTO usuarioAtualizado)
        {
           var usuario = _usuarioRepository.AtualizarUsuario(id, usuarioAtualizado).ToUsuarioDTO();

           if(usuario == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarUsuario([FromRoute] int id)
        {
            var usuarioDeletado = _usuarioRepository.DeletarUsuario(id).ToUsuarioDTO();
            if(usuarioDeletado == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}