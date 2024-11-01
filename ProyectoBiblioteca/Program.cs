using Aplicacion.Interfaces;
using Aplicacion.Servicios;
using Contract.Interfaces;
using Contract.LibroContract;
using Dominio.Entidades;
using Dominio.Interfaces;
using Infraestructura;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.AddSecurityDefinition("ProyectoBiblioteca", new OpenApiSecurityScheme() //Esto va a permitir usar swagger con el token.
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "Acá pegar el token generado al loguearse."
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ProyectoBiblioteca" } //Tiene que coincidir con el id seteado arriba en la definición
                }, new List<string>() }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    setupAction.IncludeXmlComments(xmlPath);

});




builder.Services.AddDbContext<AplicacionDbContext>(opciones => opciones.UseSqlite(
    builder.Configuration.GetConnectionString("DbConnectionString")
    ));
// Registro del repositorio base para cualquier tipo genérico
builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));



// Registro de otros servicios específicos

builder.Services.AddScoped<IUserService, UserService>();

// Agrega otros servicios que necesites, como AutoMapper si usas mapeos.
builder.Services.AddScoped<ILibroMapping, LibroMapping>();

builder.Services.AddAuthentication("Bearer")
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["AuthenticationServiceOptions:Issuer"],
                    ValidAudience = builder.Configuration["AuthenticationServiceOptions:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["AuthenticationServiceOptions:SecretForKey"]!))
                };
            }
        );

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
