using Microsoft.IdentityModel.Tokens;
using PeliculasAPI.Data;
using PeliculasAPI.Modelos;
using PeliculasAPI.Modelos.Dtos;
using PeliculasAPI.Repositorio.IRepositorio;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XSystem.Security.Cryptography;

namespace PeliculasAPI.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ApplicationDbContext _context;
        private string claveSecreta;
        public UsuarioRepositorio(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            claveSecreta = config.GetValue<string>("ApiSettings:Secreta");

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

        public async Task<UsuarioLoginRespuestaDto> GetUsuarioLogin(UsuarioLoginDto usuarioLoginDto)
        {
            var passwordEncriptado = obtenermd5(usuarioLoginDto.Password);
            var usuario = _context.Usuario.FirstOrDefault(x => x.NombreUsuario.ToLower() == usuarioLoginDto.NombreUsuario.ToLower() 
                            && x.Password == passwordEncriptado);

            // validamos si el usuario existe
            if (usuario == null)
            {

                return new UsuarioLoginRespuestaDto()
                {
                    Token = "",
                    Usuario = null
                };
            }

            // Aqui existe el usuario y se le asigna un token
            var manejadorToken = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(claveSecreta);

            // Creamos el descriptor del token
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[] // aqui se asignan los claims del token
                {
                    new Claim(ClaimTypes.Name, usuario.Nombre.ToString()), // claim del nombre del usuario
                    new Claim(ClaimTypes.Role, usuario.Role) // claim del rol del usuario
                }),
                Expires = DateTime.UtcNow.AddDays(7), // tiepmpo de expiracion del token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature) // algoritmo de encriptacion del token
            };

            var token = manejadorToken.CreateToken(tokenDescriptor); // creamos el token

            UsuarioLoginRespuestaDto usuarioLoginRespuestaDto = new UsuarioLoginRespuestaDto()
            {
                Token = manejadorToken.WriteToken(token), // escribimos el token
                Role = usuario.Role,
                Usuario = usuario
            };

            return usuarioLoginRespuestaDto;
        }

    }
}
