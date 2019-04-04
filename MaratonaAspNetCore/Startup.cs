using System;
using FluentValidation;
using FluentValidation.AspNetCore;
using MaratonaAspNetCore.Dados.AcessoDados.Repositorios;
using MaratonaAspNetCore.Models.Model;
using MaratonaAspNetCore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoBase.AcessoDados;
using ProjetoBaseMVC.Model.Validations;

namespace MaratonaAspNetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ApplicationContext>();
            services.AddTransient<DBInitializer>();
            services.AddTransient<ProdutoRepositorio>();
            services.AddTransient<TipoProdutoRepositorio>();

            services.AddDataProtection().UnprotectKeysWithAnyCertificate();

            services.AddMvc().AddFluentValidation();
            services.AddTransient<IValidator<Produto>, ProdutoValidator>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            string connectionSrting = Configuration.GetConnectionString("ApplicationContext");

            services.AddDbContext<ApplicationContext>((optBuilder) => { optBuilder.UseSqlServer(connectionSrting); });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Produtos}/{action=Index}/{id?}");
            });

            serviceProvider.GetService<DBInitializer>().Init();
        }
    }
}
