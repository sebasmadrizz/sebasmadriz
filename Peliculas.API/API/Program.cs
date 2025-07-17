using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using DA;
using DA.Repositorio;
using Flujo;
using Reglas;
using Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPeliculaFlujo, PeliculaFlujo>();
builder.Services.AddScoped<ISeriesFlujo, SeriesFlujo>();
builder.Services.AddScoped<IRepositorioDapper,RepositorioDapper >();
builder.Services.AddScoped<IPeliculasServicio, PeliculasServicio>();
builder.Services.AddScoped<ISeriesServicio, SeriesServicio>();
builder.Services.AddScoped<IConfiguracion, Configuracion>();
builder.Services.AddScoped<IPeliculaFavFlujo, PeliculasFavFlujo>();
builder.Services.AddScoped<IPeliculaFavDA, PeliculaFavDA>();

builder.Services.AddScoped<ICategoriasServicio, CategoriasServicio>();
builder.Services.AddScoped<ICategoriasFlujo, CategoriasFlujo>();

builder.Services.AddScoped<IPeliculaFavServicio, PeliculaFavServicio>();



builder.Services.AddScoped<IListaDeVisualizacionFlujo, ListaDeVisualizacionFlujo>();
builder.Services.AddScoped<IListaDeVisualizacionDA, ListaDeVisualizacionDA>();
builder.Services.AddScoped<IListaDeVisualizacionServicio, ListaDeVisualizacionServicio>();



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
