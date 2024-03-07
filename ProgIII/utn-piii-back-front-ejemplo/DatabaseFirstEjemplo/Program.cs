using System.Reflection;
using DatabaseFirstEjemplo.Models;
using DatabaseFirstEjemplo.Servicios.Personas;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EfdatabaseFirstContext>();
builder.Services.AddMediatR((config) => {
    config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});

// ¿Qué hace AddScoped?
builder.Services.AddScoped<IExistePersonaServicio, ExistePersonaServicio>();

var app = builder.Build();

app.UseCors((config) => {
    config.AllowAnyOrigin();
    config.AllowAnyHeader();
});

app.UseCors((configuracion) =>
{
    configuracion.AllowAnyOrigin();
});

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
