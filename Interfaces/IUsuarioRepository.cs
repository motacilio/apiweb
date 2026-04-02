using apiweb.Dto;
using apiweb.Entity;
using apiweb.Query;

namespace apiweb.Interfaces
{
    public interface IUsuarioRepository
    {
        Task AdicionarUsuarioAsync(UsuarioEntity usuario);

        Task<List<UsuarioEntity>> ListarUsuariosAsync(ObjectQuery query);

        Task<UsuarioEntity?> AcharUsuarioPorIdAsync(int id);

        Task<UsuarioEntity?> AtualizarUsuarioAsync(int id, UsuarioDTO usuario);

        Task<UsuarioEntity?> DeletarUsuarioAsync(int id);

        Task<bool> UsuarioExiste(int id);
    }
}