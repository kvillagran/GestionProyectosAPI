using AutoMapper;
using GestionProyectosAPI.Data;
using GestionProyectosAPI.Profiles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Configurar la cadena de conexi�n a la base de datos
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configurar Entity Framework Core con SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Configurar ASP.NET Core Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Configurar autenticaci�n por cookies para Identity
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/api/Auth/login"; // Ruta de login si no est� autenticado
    options.AccessDeniedPath = "/api/Auth/access-denied"; // Ruta si no tiene permisos suficientes
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // Duraci�n de la cookie
    options.SlidingExpiration = true; // Renovaci�n autom�tica de la cookie
});

// Configurar AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Configurar los controladores y manejar ciclos de referencias
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Ignorar referencias circulares para evitar ciclos infinitos
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// Configurar Swagger para la documentaci�n de API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Crear el scope para ejecutar el DataSeeder para los roles iniciales
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    // Ejecutar el m�todo SeedRoles para crear los roles iniciales
    await DataSeeder.SeedRoles(roleManager);
}

// Configurar el pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Configurar la autenticaci�n y autorizaci�n
app.UseAuthentication(); // Esto debe ir antes de Authorization
app.UseAuthorization();

app.MapControllers();

app.Run();
