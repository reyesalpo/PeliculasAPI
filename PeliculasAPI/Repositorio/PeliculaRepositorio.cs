using Microsoft.EntityFrameworkCore;
using PeliculasAPI.Data;
using PeliculasAPI.Modelos;
using PeliculasAPI.Repositorio.IRepositorio;

namespace PeliculasAPI.Repositorio
{
    public class PeliculaRepositorio : IPeliculaRepositorio
    {
        private readonly ApplicationDbContext _context;

        public PeliculaRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool ActualizarPelicula(Pelicula pelicula)
        {
            pelicula.FechaCreacion = DateTime.Now;

            // Arreglar problema del update con el put
            var peliculaExistente = _context.Pelicula.Find(pelicula.PeliculaId);

            if (peliculaExistente == null)
            {
                _context.Entry(pelicula).CurrentValues.SetValues(pelicula);
            }
            _context.Pelicula.Update(pelicula);
            return Guardar();
        }

        public bool BorrarPelicula(Pelicula pelicula)
        {
            _context.Pelicula.Remove(pelicula);
            return Guardar();
        }

        public IEnumerable<Pelicula> BuscarPelicula(string nombre)
        {
            
            IQueryable<Pelicula> query = _context.Pelicula;

            if(!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(x => x.Nombre.Contains(nombre) || x.Descripcion.Contains(nombre));
            }
            return query.ToList();
        }

        public bool CrearPelicula(Pelicula pelicula)
        {
            pelicula.FechaCreacion = DateTime.Now;
            _context.Pelicula.Add(pelicula);
            return Guardar();
        }

        public bool ExistePelicula(int peliculaId)
        {
            return _context.Pelicula.Any(x => x.PeliculaId == peliculaId);
        }

        public bool ExistePelicula(string Nombre)
        {
            bool valor = _context.Pelicula.Any(x => x.Nombre.ToLower().Trim() == Nombre.ToLower().Trim());

            return valor;
        }

        public ICollection<Pelicula> GetPeliculas()
        {
            return _context.Pelicula.OrderBy(x => x.Nombre).ToList();
        }

        public Pelicula GetPeliculas(int peliculaId)
        {
            return _context.Pelicula.FirstOrDefault(x => x.PeliculaId == peliculaId);
        }

        public ICollection<Pelicula> GetPeliculasCategoria(int categoriaId)
        {
            return _context.Pelicula.Include(x => x.Categoria).Where(x => x.CategoriaId == categoriaId).ToList();
        } 

        public bool Guardar()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }
    }
}
