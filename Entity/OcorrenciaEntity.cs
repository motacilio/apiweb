using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiweb.Entity
{   
    
    public class OcorrenciaEntity
    {
        public int id {get;set;}
        public string? titulo {get;set;} = string.Empty;
        public string? detalhes {get;set;} = string.Empty;
        public DateTime dataOcorrencia {get;set;}
        public int usuarioId {get;set;}

        // Atributo de navegacao (serve apenas para navegar para a classe com mais facildiade no codigo)
        public UsuarioEntity? usuario {get;set;} 
    }
}