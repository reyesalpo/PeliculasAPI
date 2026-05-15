using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PeliculasAPI.Data;
using PeliculasAPI.PeliculasMapper;
using PeliculasAPI.Repositorio;
using PeliculasAPI.Repositorio.IRepositorio;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(opciones => 
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSQL")));

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

// Agregar los repositorios
builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
builder.Services.AddScoped<IPeliculaRepositorio, PeliculaRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();


// Agregar el autoMapper
builder.Services.AddAutoMapper(cfg => { }, AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
