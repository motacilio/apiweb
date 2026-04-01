using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace apiweb.Entity
{
    public class UsuarioEntity
    {
        public int id { get; set; }
        public string nome { get; set; } = string.Empty;
        public int idade { get; set; }
    }
}
