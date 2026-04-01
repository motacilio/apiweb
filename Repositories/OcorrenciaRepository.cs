using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiweb.Data;
using apiweb.Entity;
using apiweb.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace apiweb.Repositories
{
    public class OcorrenciaRepository : IOcorrenciaRepository
    {

        private readonly UsuarioContext _context;
        public OcorrenciaRepository(UsuarioContext context)
        {
            _context = context;
        }

        public async Task CriarOcorrencia(OcorrenciaEntity ocorrencia)
        {
            await _context.Ocorrencias.AddAsync(ocorrencia);

            await _context.SaveChangesAsync();
        }
        public async Task<OcorrenciaEntity> RetornarOcorrenciaPorId(int id)
        {
            var ocorrencia = await _context.Ocorrencias.FindAsync(id);
            if(ocorrencia == null)
            {
                return null;
            }

            return ocorrencia;
        }

        public async Task<List<OcorrenciaEntity>> RetornarOcorrencias()
        {
            var ocorrencias = await _context.Ocorrencias.ToListAsync();
            return ocorrencias;
        }
    }
}