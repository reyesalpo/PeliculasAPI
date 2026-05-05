using PeliculasAPI.Data;
using PeliculasAPI.Modelos;
using PeliculasAPI.Modelos.Dtos;
using PeliculasAPI.Repositorio.IRepositorio;

namespace PeliculasAPI.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public Usuario GetUsuario(int categoriaId)
        {
            return _context.Usuario.FirstOrDefault(x => x.Id == categoriaId);
        }

        public ICollection<Usuario> GetUsuarios()
        {
            return _context.Usuario.OrderBy(x => x.Nombre).ToList();
        }

        public bool IsUniQueUSer(string usuario)
        {
            return !_context.Usuario.Any(x => x.NombreUsuario.ToLower() == usuario.ToLower());
        }

        public Task<bool> Registro(UsuarioRegistroDto usuarioRegistroDto)
        {
            throw new NotImplementedException();
        }
        public Task<UsuarioLoginRespuestaDto> GetUsuarioLogin(UsuarioLoginDto usuarioLoginDto)
        {
            throw new NotImplementedException();
        }
    }
}
