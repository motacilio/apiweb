using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiweb.Dto;
using apiweb.Entity;

namespace apiweb.Interfaces
{
    public interface IOcorrenciaRepository
    {
        Task<List<OcorrenciaEntity>?> RetornarOcorrencias();
        Task<OcorrenciaEntity?> RetornarOcorrenciaPorId(int id);
        Task CriarOcorrencia(OcorrenciaEntity ocorrencia);

    }
}