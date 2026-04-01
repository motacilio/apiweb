using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiweb.Dto;
using apiweb.Entity;
using apiweb.Model;

namespace apiweb.Data
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly UsuarioContext _context;

        public UsuarioRepository(UsuarioContext context)
        {
            _context = context;
        } 
        public void AdicionarUsuario(UsuarioEntity usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public UsuarioEntity? AcharUsuarioPorId(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public List<UsuarioEntity> ListarUsuarios()
        {
            return _context.Usuarios.ToList();
            
        }

        public UsuarioEntity? AtualizarUsuario(int id, UsuarioDTO usuarioAtualizado)
        {
            var usuarioExistente = _context.Usuarios.FirstOrDefault(u => u.id == id);
            if(usuarioExistente == null)
            {
                return null;
            }
            
            usuarioExistente.nome = usuarioAtualizado.nome;
            usuarioExistente.idade = usuarioAtualizado.idade;
            _context.SaveChanges();

            return usuarioExistente;
        }

        public UsuarioEntity? DeletarUsuario(int id)
        {
            var usuarioExistente = _context.Usuarios.FirstOrDefault(u => u.id == id);
            if(usuarioExistente == null)
            {
                return null;
            }
            _context.Usuarios.Remove(usuarioExistente);
            _context.SaveChanges();
            return usuarioExistente;
        }
        
       
    }
}