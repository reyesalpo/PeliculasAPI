using PeliculasAPI.Modelos;

namespace PeliculasAPI.Repositorio.IRepositorio
{
    public interface ICategoriaRepositorio
    {
        ICollection<Categoria> GetCategorias();
        Categoria GetCategoria(int categoriaId);
        bool ExisteCategoria(int categoriaId);
        bool ExisteCategoria(string Nombre);
        bool CrearCategoria(Categoria categoria);
        bool ActualizarCategoria(Categoria categoria);
        bool BorrarCategoria(Categoria categoria);
        bool Guardar();
    }
}
