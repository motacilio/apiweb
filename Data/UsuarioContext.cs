using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiweb.Entity;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace apiweb.Data
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext (DbContextOptions<UsuarioContext> options) : base(options){}
        public DbSet<UsuarioEntity> Usuarios {get;set;}
    }
}