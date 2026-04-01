using apiweb.Dto;
using apiweb.Entity;

namespace apiweb.Interfaces
{
    public interface IUsuarioRepository
    {
        Task AdicionarUsuarioAsync(UsuarioEntity usuario);

        Task<List<UsuarioEntity>> ListarUsuariosAsync();

        Task<UsuarioEntity?> AcharUsuarioPorIdAsync(int id);

        Task<UsuarioEntity?> AtualizarUsuarioAsync(int id, UsuarioDTO usuario);

        Task<UsuarioEntity?> DeletarUsuarioAsync(int id);

        Task<bool> UsuarioExiste(int id);
    }
}