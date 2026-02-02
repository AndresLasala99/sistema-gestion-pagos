using CasosUso.InterfacesCU;
using LogicaAccesoDatos.EF;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.CasosUso;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            var archivo = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var ruta=Path.Combine(AppContext.BaseDirectory, archivo);

            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });
                options.IncludeXmlComments(ruta);
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
            });


            builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuariosBD>();
            builder.Services.AddScoped<IRepositorio<Equipo>, RepositorioEquiposBD>();
            builder.Services.AddScoped<IRepositorioPagos, RepositorioPagosBD>();
            builder.Services.AddScoped<IRepositorioAuditorias, RepositorioAuditoriaBD>();
            builder.Services.AddScoped<IRepositorio<Gasto>, RepositorioGastosBD>();

            builder.Services.AddScoped<IBuscarPagoPorId, CUBuscarPagoPorId>();
            builder.Services.AddScoped<IAltaPago, CUAltaPago>();
            builder.Services.AddScoped<IListadoAuditoriasDeUnTipoDeGasto, CUListadoAuditoriasDeUnTipoDeGasto>();
            builder.Services.AddScoped<ILoginUsuario, CULoginUsuario>();
            builder.Services.AddScoped<IListadoPagosDeUnUsuario, CUListadoPagosDeUnUsuario>();
            builder.Services.AddScoped<IListadoEquiposConPagosUnicosMayoresA, CUListadoEquiposConPagosUnicosMayoresA>();
            builder.Services.AddScoped<IResetearPass, CUResetearPass>();
            builder.Services.AddScoped<IBuscarGastoPorId, CUBuscarGastoPorId>();
            builder.Services.AddScoped<IListadoGastos, CUListadoGastos>();
            builder.Services.AddScoped<IListadoUsuarios, CUListadoUsuarios>();

            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddDbContext<ObligatorioContext>(options => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=BaseObligatorio; Integrated Security=true;"));
            }
            if (builder.Environment.IsProduction())
            {
                builder.Services.AddDbContext<ObligatorioContext>(options => options.UseSqlServer("Server=tcp:serverobligatoriop3.database.windows.net,1433;Initial Catalog=obligatorioP3;Persist Security Info=False;User ID=adminandres;Password=Obligatoriop3!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
            }

            //AGREGADO PARA USAR JWT
            var claveSecreta = "ZWRpw6fDo28gZW0gY29tcHV0YWRvcmE=";
            builder.Services.AddAuthentication(aut =>
            {
                aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(aut =>
            {
                aut.RequireHttpsMetadata = false;
                aut.SaveToken = true;
                aut.TokenValidationParameters = new TokenValidationParameters
                {
                    RoleClaimType = ClaimTypes.Role,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(claveSecreta)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            builder.Services.AddAuthorization();

            /////////////////////////////////////////////

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}


//anaper@laempresa.com GERENTE   pass gerente1
//brugar@laempresa.com ADMIN    pass admin123
//carrod@laempresa.com EMPLEADO    pass emple123