using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiweb.Dto;
using apiweb.Entity;
using apiweb.Interfaces;
using apiweb.Mappers;
using apiweb.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace apiweb.Controller
{
    [ApiController]
    [Route("api/v1/ocorrencia")]
    public class OcorrenciaController : ControllerBase
    {
        
        private readonly IOcorrenciaRepository _ocorrenciaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public OcorrenciaController(IOcorrenciaRepository ocorrenciaRepository, IUsuarioRepository usuarioRepository)
        {
            _ocorrenciaRepository = ocorrenciaRepository;
            _usuarioRepository = usuarioRepository;
        }



        [HttpPost("{id}")]
        public async Task<IActionResult> AdicionarOcorrencia([FromRoute] int id, [FromBody] CriarOcorrenciaDTO ocorrencia)
        {
            if(!await _usuarioRepository.UsuarioExiste(id))
            {
                return BadRequest("Usuario não existe");
            }
            
            await _ocorrenciaRepository.CriarOcorrencia(ocorrencia.ToOcorrenciaEntity(id));

            return Ok();
        }


        [HttpGet]
        public async Task<IActionResult> RetornarOcorrencias()
        {
            var ocorrencias = await _ocorrenciaRepository.RetornarOcorrencias();
            var ocorrenciasDTO = ocorrencias.Select(s => s.ToOcorrenciaDTO());
            
            return Ok(ocorrenciasDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RetornarOcorrenciaPorId([FromRoute] int id)
        {
            var ocorrencia = await _ocorrenciaRepository.RetornarOcorrenciaPorId(id);
            if(ocorrencia == null)
            {
                return NotFound();
            }
            return Ok(ocorrencia.ToOcorrenciaDTO());
        }

    }
}