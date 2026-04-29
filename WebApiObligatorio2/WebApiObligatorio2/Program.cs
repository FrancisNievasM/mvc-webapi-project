using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaDatos.Repositorios;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace WebApiObligatorio2 {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IRepositorioArticulos, RepositorioArticulos>();
            builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();
            builder.Services.AddScoped<IRepositorioParametros, RepositorioParametros>();
            builder.Services.AddScoped<IRepositorio<TipoMovimiento>, RepositorioTipoMovimiento>();
            builder.Services.AddScoped<IRepositorioMovimiento, RepositorioMovimiento>();
            builder.Services.AddScoped<ICUAltaTipoMovimiento, CUAltaTipoMovimiento>();
            builder.Services.AddScoped<ICUActualizarTopeCant, CUActualizarTopeCant>();
            builder.Services.AddScoped<ICUListarArticulos, CUListarArticulos>();
            builder.Services.AddScoped<ICULoginUsuarios, CULoginUsuarios>();
            builder.Services.AddScoped<ICUArticulosEntreFechas, CUArticulosEntreFechas>();
            builder.Services.AddScoped<ICUCantidadArticulosEntreFechas, CUCantidadArticulosEntreFechas>();
            builder.Services.AddScoped<ICUCantidadMovimientosDeArticulo, CUCantidadMovimientosDeArticulo>();
            builder.Services.AddScoped<ICUCantMaxMovPorPagina, CUCantMaxMovPorPagina>();
            builder.Services.AddScoped<ICUCantMaxArtPorPagina, CUCantMaxArtPorPagina>();
            builder.Services.AddScoped<ICUResumenMovimientos, CUResumenMovimientos>();
            builder.Services.AddScoped<ICUBajaTipoMovimiento, CUBajaTipoMovimiento>();
            builder.Services.AddScoped<ICUUpdateTipoMovimiento, CUUpdateTipoMovimiento>();
            builder.Services.AddScoped<ICUBuscarTipoMovimiento, CUBuscarTipoMovimiento>();
            builder.Services.AddScoped<ICUBuscarMovimientosDeArticulo, CUBuscarMovimientosDeArticulo>();
            builder.Services.AddScoped<ICUListarTipoMovimientos, CUListarTipoMovimientos>();
            builder.Services.AddScoped<ICUBuscarUsuarioPorMail, CUBuscarUsuarioPorMail>();
            builder.Services.AddScoped<ICUBuscarArticuloPorId, CUBuscarArticuloPorId>();
            builder.Services.AddScoped<ICUAltaMovimiento, CUAltaMovimiento>();
            builder.Services.AddScoped<ICUBuscarMovimientoPorId, CUBuscarMovimientoPorId>();
            string strCon = builder.Configuration.GetConnectionString("MiConexion");
            builder.Services.AddDbContext<LibreriaContext>(options => options.UseSqlServer(strCon));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();






            var claveSecreta = "ZWRpw6fDo28gZW0gY29tcHV0YWRvcmE=";
            builder.Services.AddAuthentication(aut => {
                aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(aut => {
                aut.RequireHttpsMetadata = false;
                aut.SaveToken = true;
                aut.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(claveSecreta)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            var app = builder.Build();
            




            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
