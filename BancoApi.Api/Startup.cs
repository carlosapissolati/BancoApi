using AutoMapper;
using BancoApi.Domain.Interfaces;
using BancoApi.Domain.Notificacoes;
using BancoApi.Domain.Repository;
using BancoApi.Domain.Services;
using BancoApi.Infra.Context;
using BancoApi.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BancoApi.Api
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
            services.AddControllers();

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<BancoContext, BancoContext>();
            services.AddScoped<INotificador, Notificador>();

            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IClienteService, ClienteService>();

            services.AddTransient<IEnderecoRepository, EnderecoRepository>();
            services.AddTransient<IEnderecoService, EnderecoService>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
