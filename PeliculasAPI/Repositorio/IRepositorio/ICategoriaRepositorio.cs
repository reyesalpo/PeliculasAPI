using PeliculasAPI.Modelos;

namespace PeliculasAPI.Repositorio.IRepositorio
{
    public interface ICategoriaRepositorio
    {
        ICollection<Categoria> Categorias();
        Categoria getCategoria(int categoriaId);
        bool ExisteCategoria(int categoriaId);
        bool ExisteCategoria(string Nombre);
        bool CrearCategoria(Categoria categoria);
        bool ActualizarCategoria(Categoria categoria);
        bool BorrarCategoria(Categoria categoria);
        bool Guardar();
    }
}
