using System.Reflection;
using System.Reflection.Metadata;
using DB;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ZoosContext>(options => 
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("ZoosConnection"));
});

builder.Services.AddMediatR((config) => {
    config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
}
);

builder.Services.AddFluentValidation((config) =>
{
    config.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});

// builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Esto es para que se hagan migraciones cada vez que se ejecute la app.
// using (var scope = app.Services.CreateScope()){
//     var context = scope.ServiceProvider.GetRequiredService<ZoosContext>();
//     context.Database.Migrate();
// }

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
