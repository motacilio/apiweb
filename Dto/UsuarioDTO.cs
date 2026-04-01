using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiweb.Entity;

namespace apiweb.Dto
{
    public class UsuarioDTO
    {
        public int id { get; set; }
        public string nome { get; set; } = string.Empty;
        public int idade { get; set; }
        public List<OcorrenciaDTO> ocorrencias {get;set;}   
    }
}