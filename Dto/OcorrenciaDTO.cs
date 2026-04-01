using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiweb.Dto
{
    public class OcorrenciaDTO
    {
        public string titulo {get;set;} = string.Empty;
        public string detalhes {get;set;} = string.Empty;
        public int usuarioId {get;set;}

    }
}