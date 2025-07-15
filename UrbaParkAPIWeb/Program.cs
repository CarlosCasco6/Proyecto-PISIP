using Microsoft.EntityFrameworkCore;
using UrbaPark.Aplicacion.Servicio;
using UrbaPark.Aplicacion.ServicioImpl;
using UrbaPark.Infraestructura.AccesoDatos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//1. Leer la variable de conexión de la base de datos desde el archivo appsettings.json
var conexiondb = builder.Configuration.GetConnectionString("ConexionDBUrbaPark");

//2. Registrar el contexto de la base de datos con la cadena de conexión
builder.Services.AddDbContext<urbaparkDBContext>(options =>
    options.UseSqlServer(conexiondb), ServiceLifetime.Scoped);

//3. configurar los servicios de la aplicaciónbuilder.Services.AddScoped<ICronogramasSoporteServicio, CronogramasSoporteServicioImpl>();


builder.Services.AddScoped<ICronogramasSoporteServicio, CronogramasSoporteServicioImpl>();
builder.Services.AddScoped<ICronogramasTecnicosServicio, CronogramasTecnicosServicioImpl>();
builder.Services.AddScoped<IIncidenciasSoftwareServicio, IncidenciasSoftwareServicioImpl>();
builder.Services.AddScoped<IInformesSoftwareServicio, InformesSoftwareServicioImpl>();
builder.Services.AddScoped<IParqueaderosServicio, ParqueaderosServicioImpl>();
builder.Services.AddScoped<IRolesServicio, RolesServicioImpl>();
builder.Services.AddScoped<ISoftwareParqueaderosServicio, SoftwareParqueaderosServicioImpl>();
builder.Services.AddScoped<ISolucionesAplicadasServicio, SolucionesAplicadasServicioImpl>();
builder.Services.AddScoped<ITecnicosSoftwareServicio, TecnicosSoftwareServicoImpl>();
builder.Services.AddScoped<IUsuariosServicio, UsuariosServicioImpl>();
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
