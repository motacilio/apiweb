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
        
        public static OcorrenciaEntity ToOcorrenciaEntity(this CriarOcorrenciaDTO ocorrenciaDTO)
        {
            return new OcorrenciaEntity
            {
                titulo = ocorrenciaDTO.titulo,
                detalhes = ocorrenciaDTO.detalhes,
                usuarioId = ocorrenciaDTO.usuarioId,
                dataOcorrencia = DateTime.Now
            };
        }

        public static OcorrenciaDTO ToOcorrenciaDTO(this OcorrenciaEntity ocorrenciaEntity)
        {
            return new OcorrenciaDTO
            {
                titulo = ocorrenciaEntity.titulo,
                detalhes = ocorrenciaEntity.detalhes,
                usuarioId = ocorrenciaEntity.usuarioId
            };
        }

    }
}