using PeliculasAPI.Data;
using PeliculasAPI.Modelos;
using PeliculasAPI.Modelos.Dtos;
using PeliculasAPI.Repositorio.IRepositorio;
using XSystem.Security.Cryptography;

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

        public async Task<Usuario> Registro(UsuarioRegistroDto usuarioRegistroDto)
        {
            var paswordEncirptado = obtenermd5(usuarioRegistroDto.Password);

            Usuario usuario = new Usuario()
            {
                NombreUsuario = usuarioRegistroDto.NombreUsuario,
                Password = paswordEncirptado,
                Nombre = usuarioRegistroDto.Nombre,
                Role = usuarioRegistroDto.Role
            };

            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
            usuario.Password = paswordEncirptado;
            return usuario;
        }

        // Encripatar la contrasenia
        public static string obtenermd5(string password)
        { 
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();

            byte[] data = System.Text.Encoding.UTF8.GetBytes(password);
            data = x.ComputeHash(data);
            string resp = "";
            for (int i = 0; i < data.Length; i++) { 
                resp += data[i].ToString("x2").ToLower();
            }
            return resp;
        }

        public Task<UsuarioLoginRespuestaDto> GetUsuarioLogin(UsuarioLoginDto usuarioLoginDto)
        {
            throw new NotImplementedException();
        }
         
    }
}
