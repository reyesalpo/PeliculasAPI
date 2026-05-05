using AutoMapper;
using PeliculasAPI.Modelos;
using PeliculasAPI.Modelos.Dtos;

namespace PeliculasAPI.PeliculasMapper
{
    public class PeliculasMapper: Profile
    {
        public PeliculasMapper()
        {
            // Mappear los modelos con el Dtos
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<Categoria, CrearCategoriaDto>().ReverseMap();

            CreateMap<Pelicula, PeliculaDto>().ReverseMap();
            CreateMap<Pelicula, CrearPeliculaDto>().ReverseMap();
        }
    }
}
