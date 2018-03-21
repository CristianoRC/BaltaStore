using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.Services;
using BaltaStore.Infra.StoreContext.DataContexts;
using BaltaStore.Infra.StoreContext.Repositories;
using BaltaStore.Infra.StoreContext.Services;
using Elmah.Io.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace BaltaStore.API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //Compressão
            services.AddResponseCompression();

            //Injeção de dependência
            //Vê se tem um na memoria e usa ele
            services.AddScoped<BaltaDataContext, BaltaDataContext>();

            //Instancia um novo
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerHandler, CustomerHandler>();

            //Documentação
            services.AddSwaggerGen(
                x =>
                {
                    x.SwaggerDoc("v1", new Info { Title = "BaltaStore", Version = "v1" });
                });

            //Log
            services.AddElmahIo(x =>
            {
                x.ApiKey = "8fb0fa8302df4479b61b58f71ef36f6c";
                x.LogId = new System.Guid("565d82ac-e65e-40e7-bd50-27c5b238c37f");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            //Compressão
            app.UseResponseCompression();

            //Documentação
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BaltaStore API V1");
            });

            app.UseElmahIo();
        }
    }
}
