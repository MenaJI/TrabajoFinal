using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;
using ApiREST.ServicesImp;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace ApiREST
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiREST", Version = "v1" });
            });

            // DbContext de la Api (Entities y Identity)
            services.AddDbContext<SecurityDbContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));

            // Inyección de dependencia.

            services.AddScoped<SecurityDbContext, SecurityDbContext>();
            services.AddScoped<IRolesService, RolesService>();
            services.AddScoped<IUsuariosService, UsuariosService>();
            services.AddScoped<IEstadosCivilesService, EstadosCivilesService>();
            services.AddScoped<IGenerosService, GenerosService>();
            services.AddScoped<ILocalidadesService, LocalidadesService>();
            services.AddScoped<INacionalidadesService, NacionalidadesService>();
            services.AddScoped<ITiposDocsService, TiposDocsService>();
            services.AddScoped<ICondicionesService, CondicionesService>();
            services.AddScoped<IAulasService, AulasService>();
            services.AddScoped<IDiasService, DiasService>();
            services.AddScoped<IHorariosService, HorariosService>();
            services.AddScoped<IModulosService, ModulosService>();
            services.AddScoped<IAlumnosServices, AlumnosService>();
            services.AddScoped<ICarrerasService, CarrerasService>();
            services.AddScoped<IInscripcionCarreraService, InscripcionCarreraService>();
            services.AddScoped<IAniosService, AniosService>();
            services.AddScoped<IRegimenesService, RegimenesService>();
            services.AddScoped<ICamposService, CamposService>();
            services.AddScoped<ICondicionesCursoService, CondicionesCursoService>();
            services.AddScoped<IFormatosService, FormatosService>();
            services.AddScoped<IInscripcionesMateriaService, InscripcionesMateriaService>();
            services.AddScoped<IArchivosServices, ArchivoService>();
            services.AddScoped<IMateriasService, MateriasServices>();
            services.AddScoped<ICursosServices, CursosServices>();
            services.AddScoped<IDocentesServices, DocentesServices>();


            // Para usar Identity  
            services.AddIdentity<Usuarios, IdentityRole>()
                .AddEntityFrameworkStores<SecurityDbContext>()
                .AddDefaultTokenProviders();

            // Añadiendo Auth  
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Añadiendo un Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });

            // Para usar el AutoMapper.
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // CORS
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(option => option.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiREST v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
