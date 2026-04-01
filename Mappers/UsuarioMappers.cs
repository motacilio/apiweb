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
                nome = usuario.nome,
                idade = usuario.idade
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