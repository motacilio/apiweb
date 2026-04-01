using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiweb.Dto;
using apiweb.Entity;

namespace apiweb.Mappers
{
    public static class UsuarioMappers
    {
        
        public static UsuarioDTO ToUsuarioDTO(this UsuarioEntity usuario)
        {
            return new UsuarioDTO{
                id = usuario.id,
                nome = usuario.nome,
                idade = usuario.idade,
                ocorrencias = usuario.ocorrencias.Select(c => c.ToOcorrenciaDTO()).ToList()
            };
        }

        public static UsuarioEntity ToUsuarioEntity(this CriarUsuarioDTO usuario)
        {
            return new UsuarioEntity
            {
              nome = usuario.nome,
              idade = usuario.idade
            };
        }
    }
}