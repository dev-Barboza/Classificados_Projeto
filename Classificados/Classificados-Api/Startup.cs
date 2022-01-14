using Classificados.Dominio.Handlers;
using Classificados.Dominio.Handlers.Command;
using Classificados.Dominio.Handlers.Command.Anuncio;
using Classificados.Dominio.Handlers.Command.Usuario;
using Classificados.Dominio.Handlers.Queries.Anuncio;
using Classificados.Dominio.Handlers.Queries.Usuario;
using Classificados.Dominio.Repositories;
using Classificados.Infra.Data.Context;
using Classificados.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificados_Api
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

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                //Correção do erro object cycle
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                //Remover propriedades nulas
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

            services.AddDbContext<ClassificadosContext>(o => o.UseSqlServer("Data Source=DESKTOP-SOV61AF\\SQLEXPRESS;Initial Catalog= Classificados ;Persist Security Info=True;User ID=sa;Password=sa132"));
            //services.AddDbContext<CodeTurContext>(o => o.UseSqlServer("Data Source=KAUADEJA\\SQLEXPRESS; Initial Catalog=CodeTur; user id= sa; password=sa132"));
            //JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "classificados",
                        ValidAudience = "classificados",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ChaveSecretaClassificadosApi"))
                    };
                });

            #region Injeção Dependência Anúncios
            services.AddTransient<IAnuncioRepository, AnuncioRepository>();
            services.AddTransient<CriarAnuncioHandler, CriarAnuncioHandler>();
            services.AddTransient<AlterarAnuncioHandler, AlterarAnuncioHandler>();
            services.AddTransient<AlterarStatusAnuncioHandler, AlterarStatusAnuncioHandler>();
            services.AddTransient<ListarAnuncioHandler, ListarAnuncioHandler>();
            services.AddTransient<BuscarAnuncioTituloHandler, BuscarAnuncioTituloHandler>();
            services.AddTransient<AlterarImagemAnuncioHandler, AlterarImagemAnuncioHandler>();
            services.AddTransient<AlterarTituloAnuncioHandler, AlterarTituloAnuncioHandler>();
            services.AddTransient<DeletarAnuncioHandler, DeletarAnuncioHandler>();
            #endregion

            #region Injeção Dependência Usuario
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<CriarContaHandler, CriarContaHandler>();
            services.AddTransient<LogarHandler, LogarHandler>();
            services.AddTransient<ListarUsuarioHandler, ListarUsuarioHandler>();
            #endregion

            //SWAGGER
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Classificados", Version = "V1" });
            });

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClassificadosApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //Add cors
            app.UseCors(c => c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
