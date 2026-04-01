using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiweb.Dto;
using apiweb.Entity;

namespace apiweb.Mappers
{
    public static class OcorrenciaMapper
    {
        
        public static OcorrenciaEntity CriarOcorrenciaToOcorrenciaEntity(this CriarOcorrenciaDTO ocorrenciaDTO, int id)
        {
            return new OcorrenciaEntity
            {
                titulo = ocorrenciaDTO.titulo,
                detalhes = ocorrenciaDTO.detalhes,
                usuarioId = id
            };
        }

        public static OcorrenciaEntity AtualizarOcorrenciaToOcorrenciaEntity(this AtualizarOcorrenciaDTO ocorrencia)
        {
            return new OcorrenciaEntity
            {
              titulo = ocorrencia.titulo,
              detalhes = ocorrencia.detalhes  
            };
        }

        public static OcorrenciaDTO ToOcorrenciaDTO(this OcorrenciaEntity ocorrenciaEntity)
        {
            return new OcorrenciaDTO
            {
                id = ocorrenciaEntity.id,
                titulo = ocorrenciaEntity.titulo,
                detalhes = ocorrenciaEntity.detalhes,
                usuarioId = ocorrenciaEntity.usuarioId
            };
        }

    }
}