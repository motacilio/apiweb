using apiweb.Data;
using apiweb.Dto;
using apiweb.Entity;
using apiweb.Interfaces;
using apiweb.Query;
using Microsoft.EntityFrameworkCore;

namespace apiweb.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly UsuarioContext _context;

        public UsuarioRepository(UsuarioContext context)
        {
            _context = context;
        } 
        public async Task AdicionarUsuarioAsync(UsuarioEntity usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }
        public async Task<List<UsuarioEntity>> ListarUsuariosAsync(ObjectQuery query)
        {
            var usuarios = _context.Usuarios.Include(c => c.ocorrencias).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.nome))
            {
                usuarios = usuarios.Where(u => u.nome.Contains(query.nome));
            }

            if (!string.IsNullOrWhiteSpace(query.sortBy))
            {
                if(query.sortBy.Equals("nome", StringComparison.OrdinalIgnoreCase))
                {
                    usuarios = query.isDescending ? usuarios.OrderByDescending(u => u.nome) : usuarios.OrderBy(u => u.nome); 
                }
            }

            var skipNumber = (query.pageNumber - 1) * query.pageSize;
 
            return await usuarios.Skip(skipNumber).Take(query.pageSize).ToListAsync();
        }
        public async Task<UsuarioEntity?> AcharUsuarioPorIdAsync(int id)
        {
            var usuario = await _context.Usuarios.Include(c => c.ocorrencias).FirstOrDefaultAsync(u => u.id == id);
            return usuario;
        }

        

        public async Task<UsuarioEntity?> AtualizarUsuarioAsync(int id, UsuarioDTO usuarioAtualizado)
        {
            var usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(u => u.id == id);
            if(usuarioExistente == null)
            {
                return null;
            }
            
            usuarioExistente.nome = usuarioAtualizado.nome;
            usuarioExistente.idade = usuarioAtualizado.idade;
            await _context.SaveChangesAsync();

            return usuarioExistente;
        }

        public async Task<UsuarioEntity?> DeletarUsuarioAsync(int id)
        {
            var usuarioExistente = await  _context.Usuarios.FirstOrDefaultAsync(u => u.id == id);
            if(usuarioExistente == null)
            {
                return null;
            }
            _context.Usuarios.Remove(usuarioExistente);
            await _context.SaveChangesAsync();
            return usuarioExistente;
        }

        public async Task<bool> UsuarioExiste(int id)
        {
           return await _context.Usuarios.AnyAsync(u => u.id == id);      
        }
    }
}