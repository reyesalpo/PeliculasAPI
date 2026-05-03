using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.Modelos.Dtos
{
    public class CategoriaDto
    {
        public int CategoriaId { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(50, ErrorMessage = "El numero maximo de caracteres es de 100.")]
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
    }

    public class CrearCategoriaDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(50, ErrorMessage = "El numero maximo de caracteres es de 100.")]
        public string Nombre { get; set; }
    }
}
