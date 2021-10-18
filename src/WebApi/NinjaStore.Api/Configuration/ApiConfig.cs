using NinjaStore.WebApi.Core.Identidade;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NinjaStore.Produtos.Infra.Data;
using NinjaStore.Clientes.Infra.Data;
using NinjaStore.Pedidos.Infra.Data;

namespace NinjaStore.Api.Configuration
{
    public static class ApiConfig
    {
        private const string PermissoesEspecificasDeOrigem = "_permissoesEspecificasDeOrigem";

        public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            //Contexts
            services.AddDbContext<ProdutoContextDB>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ProdutoConnection")));

            services.AddDbContext<ClienteContextDB>(options =>
               options.UseSqlServer(configuration.GetConnectionString("ClienteConnection")));

            services.AddDbContext<PedidoContextDB>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PedidoConnection")));



            //Query Contexts
            services.AddDbContext<ProdutoQueryContextDB>(options =>
              options.UseSqlServer(configuration.GetConnectionString("QueryConnection")));

            services.AddDbContext<ClienteQueryContextDB>(options =>
              options.UseSqlServer(configuration.GetConnectionString("QueryConnection")));

            services.AddDbContext<PedidoQueryContextDB>(options =>
              options.UseSqlServer(configuration.GetConnectionString("QueryConnection")));



            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            
            services.AddCors(options =>
            {
                options.AddPolicy(PermissoesEspecificasDeOrigem,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            return services;
        }

        public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(PermissoesEspecificasDeOrigem);

            app.UseAuthConfiguration();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}