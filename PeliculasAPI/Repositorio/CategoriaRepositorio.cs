using PeliculasAPI.Data;
using PeliculasAPI.Modelos;
using PeliculasAPI.Repositorio.IRepositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PeliculasAPI.Repositorio
{
    public class CategoriaRepositorio: ICategoriaRepositorio
    {
        private readonly ApplicationDbContext _context;

        public CategoriaRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool ActualizarCategoria(Categoria categoria)
        {
            categoria.FechaCreacion = DateTime.Now;
            _context.Categoria.Update(categoria);
            return Guardar();
        }

        public bool BorrarCategoria(Categoria Categoria)
        {
            
            _context.Categoria.Remove(Categoria);
            return Guardar();
        }

        public Categoria GetCategoria(int categoriaId)
        {
            return _context.Categoria.FirstOrDefault(x => x.CategoriaId == categoriaId);
        }

        public ICollection<Categoria> GetCategorias()
        {
            return _context.Categoria.OrderBy(x => x.Nombre).ToList();
        }

        public bool CrearCategoria(Categoria categoria)
        {
            categoria.FechaCreacion = DateTime.Now;
            _context.Categoria.Add(categoria);
            return Guardar();
        }

        public bool ExisteCategoria(int categoriaId)
        {
            return _context.Categoria.Any(x => x.CategoriaId == categoriaId);
        }

        public bool ExisteCategoria(string Nombre)
        {
            bool valor =  _context.Categoria.Any(x => x.Nombre.ToLower().Trim() == Nombre.ToLower().Trim());

            return valor;
        }

        public bool Guardar()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }
    }
}
