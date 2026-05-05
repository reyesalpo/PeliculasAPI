using PeliculasAPI.Modelos;
using PeliculasAPI.Modelos.Dtos;

namespace PeliculasAPI.Repositorio.IRepositorio
{
    public interface IUsuarioRepositorio
    {
        ICollection<Usuario> GetUsuarios();
        Usuario GetUsuario(int categoriaId);
        bool IsUniQueUSer(string usuario);
        Task<UsuarioLoginRespuestaDto> GetUsuarioLogin(UsuarioLoginDto usuarioLoginDto);
        Task<bool> Registro(UsuarioRegistroDto usuarioRegistroDto);
    }
}
