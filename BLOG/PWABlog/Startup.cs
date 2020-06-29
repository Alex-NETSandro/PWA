using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PWABlog.Models.AcessControl;
using PWABlog.Models.Blog.Autor;
using PWABlog.Models.Blog.Categoria;
using PWABlog.Models.Blog.Etiqueta;
using PWABlog.Models.Blog.Postagem;

namespace PWABlog
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
            //Add the access control engine service
            services.AddIdentity<User,Paper>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 6;
            }).AddEntityFrameworkStores<DatabaseContext>().AddErrorDescriber<DescriptorError>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/login";
            });
            // Adicionar o serviço do banco de dados
            services.AddDbContext<DatabaseContext>();
            
            // Adicionar os serviços de ORM das entidades do domínio
            services.AddTransient<CategoriaOrmService>();
            services.AddTransient<PostagemOrmService>();
            services.AddTransient<AutorOrmService>();
            services.AddTransient<EtiquetaOrmService>();
            services.AddTransient<ControlAcessService>();

            // Adicionar os serviços que possibilitam o funcionamento dos controllers e das views
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

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