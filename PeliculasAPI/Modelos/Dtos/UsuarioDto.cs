using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.Modelos.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

    public class UsuarioRegistroDto
    {
        [Required(ErrorMessage = "El nombre usuario es obligatorio")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El password es obligatorio")]
        public string Password { get; set; }
        public string Role { get; set; }
    }
    public class UsuarioLoginDto
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "El password es obligatorio")]
        public string Password { get; set; }
    }

    public class UsuarioLoginRespuestaDto
    {
        public Usuario Usuario { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }

    public class UsuariosDatosDto
    {
        public Usuario Id { get; set; }
        public string UserName { get; set; }
        public string Nombre { get; set; }
    }
     
}
