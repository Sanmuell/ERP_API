using ErpApi.Data;
using ErpApi.Repository;
using ErpApi.Repository.Interfaces;
using ErpApi.Validator;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace ErpApi
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
            services.AddControllers()
           .AddNewtonsoftJson(options =>
           options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
           .AddFluentValidation(p => p.RegisterValidatorsFromAssemblyContaining<EmpresaValidator>());


            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IBaseRepository, BaseRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddDbContext<DataContext>();
            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ErpApi",
                    Version = "v1",

                    Description = "API para cadastramento de FORNECEDORES vinculados a " +
                    "uma EMPRESA. <br/><br/>***ATENÇÃO: utilize (1) para FISICA e (2) para JURIDICA em tipoPessoa." +
                    "<br>" +
                    "<br> Formato para busca por data ==>  yyyy-MM-dd "
                });

            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseDefaultFiles();
                app.UseStaticFiles();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ErpApi v1"));
                app.UseCors(options =>
                {
                    options.WithOrigins("http://localhost:3000");
                    options.AllowAnyMethod();
                    options.AllowAnyHeader();
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
