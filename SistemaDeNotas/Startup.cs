using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SistemaDeNotas.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaDeNotas.Data.Services;
using Syncfusion.Blazor;

namespace SistemaDeNotas
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSyncfusionBlazor();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();

            //Se registra la Entidad y Servicios
            services.AddScoped<IEstudianteService, EstudianteService>();
            services.AddScoped<IMateriaService, MateriaService>();
            services.AddScoped<IMatriculaService, MatriculaService>();
            services.AddScoped<IProfesoresService, ProfesoresService>();
            services.AddScoped<IGradoService, GradoService>();
            services.AddScoped<IListadoEstudianteProfesorService, ListadoEstudianteProfesorService>();
            services.AddScoped<IPeriodoService, PeriodoService>();
            services.AddScoped<IHorarioService, HorarioService>();



            //Conexion a la BD
            //var SqlConnectionConfiguration = new SqlConnectionConfiguration(Configuration.GetConnectionString("SqlDBContext"));
            var SqlConnectionConfiguration = new SqlConnectionConfiguration(Configuration.GetConnectionString("SqlDBContext"));
            services.AddSingleton(SqlConnectionConfiguration);
            


          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDM4MTM4QDMxMzkyZTMxMmUzMFU2bXFwL0lseEVLM09tYU9NYnpva1AvMnJaUURzU3RUSExRQ2FQNzBFdHM9");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
