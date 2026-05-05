using PeliculasAPI.Modelos;

namespace PeliculasAPI.Repositorio.IRepositorio
{
    public interface IPeliculaRepositorio
    {
        ICollection<Pelicula> GetPeliculas();
        ICollection<Pelicula> GetPeliculasCategoria(int categoriaId);
        IEnumerable<Pelicula> BuscarPelicula(string nombre);
        Pelicula GetPeliculas(int peliculaId);
        bool ExistePelicula(int peliculaId);
        bool ExistePelicula(string Nombre);
        bool CrearPelicula(Pelicula pelicula);
        bool ActualizarPelicula(Pelicula pelicula);
        bool BorrarPelicula(Pelicula pelicula);
        bool Guardar();
    }
}
