using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace PeliculasAPI.Modelos
{
    public class Pelicula
    {
        public int PeliculaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Duracion { get; set; }
        public string RutaImagen { get; set; }
        public enum TipoClasificacion { Siete, Trece, Dieciseis, Diesiocho};
        public TipoClasificacion Clasificacion { get; set; }
        public DateTime FechaCreacion { get; set; }

        // Relacion con Categoria

        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }
    }
}
