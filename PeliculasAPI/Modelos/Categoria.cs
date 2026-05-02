using System.ComponentModel.DataAnnotations;
using System.Data;

namespace PeliculasAPI.Modelos
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
    }
}
