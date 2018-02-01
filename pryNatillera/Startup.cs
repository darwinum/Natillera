using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using pryNatillera.Data;
using pryNatillera.Services;
using LibraryDato;
using LibraryServicios;
using ModelosEntidades;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace pryNatillera
{
    public class Startup
    {
        private const string enUSCulture = "es-CO";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
              */

            //DUM: Realizo un cambio de contexto para que trabaje con la libreria nueva de contexto

            //se realiza la injecion para que la aplicacion pueda trabajar con el nuevo contexto
            services.AddDbContext<LibraryDatoContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //se realiza la injeccion con el contexto para la conexion de seguriada
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //se agrega el contexto para el servicio de natilla, esto se necesita en el constructor
            services.AddScoped<INatillera, NatillaServicio>().AddDbContext<LibraryDatoContext>();

            //DUM: fin cambio de contexto.

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture(enUSCulture);
                options.SupportedCultures = new List<CultureInfo> { new CultureInfo(enUSCulture), new CultureInfo(enUSCulture) };
            });

            services.AddMvc()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeFolder("/Account/Manage");
                    options.Conventions.AuthorizePage("/Account/Logout");
                });

            // Register no-op EmailSender used by account confirmation and password reset during development
            // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=532713
            services.AddSingleton<IEmailSender, EmailSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            //DUM: inicio establacer cultura
            //var supportedCultures = new[]
            //{
            //    new CultureInfo(enUSCulture)              
            //};
            //app.UseRequestLocalization(new RequestLocalizationOptions
            //{
            //    DefaultRequestCulture = new RequestCulture(enUSCulture),
            //    // Formatting numbers, dates, etc.
            //    SupportedCultures = supportedCultures,
            //    // UI strings that we have localized.
            //    SupportedUICultures = supportedCultures
            //});

            //var supportedCultures = new[] { new CultureInfo(enUSCulture) };
            //app.UseRequestLocalization(new RequestLocalizationOptions
            //{
            //    DefaultRequestCulture = new RequestCulture(enUSCulture),
            //    SupportedCultures = supportedCultures,
            //    SupportedUICultures = supportedCultures
            //});
            //CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(enUSCulture);
            //CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(enUSCulture);
            //CultureInfo.CurrentCulture = new CultureInfo(enUSCulture);
            //CultureInfo.CurrentUICulture = new CultureInfo(enUSCulture);

           

            //DUM: Final establecer cultura.


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
