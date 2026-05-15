using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeliculasAPI.Modelos.Dtos;
using PeliculasAPI.Repositorio.IRepositorio;

namespace PeliculasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuarioRepositorio usuarioRepositorio, IMapper mapper)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetUsuarios()
        {
            var listaUsuarios = _usuarioRepositorio.GetUsuarios();

            var listaUsuariosDto = new List<UsuarioDto>();

            foreach (var lista in listaUsuariosDto)
            {
                listaUsuariosDto.Add(_mapper.Map<UsuarioDto>(lista));
            }

            return Ok(listaUsuariosDto);
        }
    }
}
