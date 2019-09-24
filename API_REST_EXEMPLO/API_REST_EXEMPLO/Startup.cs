
using API_REST_EXEMPLO.Model.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using API_REST_EXEMPLO.Repository;
using API_REST_EXEMPLO.Repository.Implementation;
using API_REST_EXEMPLO.Business;
using API_REST_EXEMPLO.Business.Implementation;
using API_REST_EXEMPLO.Repository.Generic;

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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //injeção de dependência
            services.AddScoped<IPersonBusiness, PersonBusinessImpl>();
            services.AddScoped<IPersonRepository, PersonRepositoryImpl>();

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
            app.UseMvc();
        }
    }
}
