using System.ComponentModel.DataAnnotations.Schema;

namespace PeliculasAPI.Modelos.Dtos
{
    public class PeliculaDto
    {
        public int PeliculaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Duracion { get; set; }
        public string RutaImagen { get; set; }
        public enum TipoClasificacion { Siete, Trece, Dieciseis, Diesiocho };
        public TipoClasificacion Clasificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int CategoriaId { get; set; }
    }

    public class CrearPeliculaDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Duracion { get; set; }
        public string RutaImagen { get; set; }
        public enum CrearTipoClasificacion { Siete, Trece, Dieciseis, Diesiocho };
        public CrearTipoClasificacion Clasificacion { get; set; }
        public int CategoriaId { get; set; }
    }
}
