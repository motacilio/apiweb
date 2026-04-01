using apiweb.Entity;
using Microsoft.EntityFrameworkCore;

namespace apiweb.Data
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext (DbContextOptions<UsuarioContext> options) : base(options){}
        public DbSet<UsuarioEntity> Usuarios {get;set;}
        public DbSet<OcorrenciaEntity> Ocorrencias {get;set;}
    }
}