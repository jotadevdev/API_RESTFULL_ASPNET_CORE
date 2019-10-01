
using API_REST_EXEMPLO.Model.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using API_REST_EXEMPLO.Repository;
//using API_REST_EXEMPLO.Repository.Generic.Implementation;
using API_REST_EXEMPLO.Business;
using API_REST_EXEMPLO.Business.Implementation;
using API_REST_EXEMPLO.Repository.Generic;
using Microsoft.Net.Http.Headers;
using Tapioca.HATEOAS;
using API_REST_EXEMPLO.Hypermedia;
using API_REST_EXEMPLO.Repository.Generic.Implementation;

namespace API_REST_EXEMPLO
{
    public class Startup
    {
        //construtor para configurration
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddApiVersioning();

            //Configuration conection data base
            var connectionString = _configuration["SqlServerConection:SqlServerConectionString"];
            services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(connectionString));

            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("text/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("jason", MediaTypeHeaderValue.Parse("application/json"));
            }).AddXmlSerializerFormatters();

            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ObjectContentResponseEnricherList.Add(new PersonEnricher());
            services.AddSingleton(filterOptions);


            //injeção de dependência
            services.AddScoped<IPersonBusiness, PersonBusinessImpl>();
            services.AddScoped<IBooksBusiness, BooksBusinessImpl>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepositoryImpl<>));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "DefaultApi",
                    template: "{controller=Values}/{id?}");
            });
        }
    }
}
