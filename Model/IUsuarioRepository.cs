using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiweb.Dto;
using apiweb.Entity;

namespace apiweb.Model
{
    public interface IUsuarioRepository
    {
        void AdicionarUsuario(UsuarioEntity usuario);

        List<UsuarioEntity> ListarUsuarios();

        UsuarioEntity AcharUsuarioPorId(int id);

        UsuarioEntity AtualizarUsuario(int id, UsuarioDTO usuario);

        UsuarioEntity DeletarUsuario(int id);
    }
}