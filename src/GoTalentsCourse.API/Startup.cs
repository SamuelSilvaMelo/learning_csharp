using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using GoTalentsCourse.Services;
using GoTalentsCourse.Repository;
using Microsoft.EntityFrameworkCore;
using GoTalentsCourse.Interfaces;
using GoTalentsCourse.Models;

namespace GoTalentsCourse.API
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
            services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("GoCedroTech"));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GoTalentsCourse.API", Version = "v1" });
            });
            services.AddScoped<DataContext, DataContext>();
            services.AddScoped<IStandartRepositoryOperations<StudentModel>, StudentRepository>();
            services.AddScoped<IStandartRepositoryOperations<FacilitatorModel>, FacilitatorRepository>();
            services.AddScoped<IStudentServices, StudentServices>();
            services.AddScoped<IFacilitatorServices, FacilitatorServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GoTalentsCourse.API v1"));
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
