using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using ProjetoMRV.Domain.Repository.Interfaces;
using ProjetoMRV.Domain.Service;
using ProjetoMRV.Infra.Data;
using ProjetoMRV.Infra.Repository;
using System.IO.Compression;
using System.Text.Json.Serialization;

namespace ProjetoMRV
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
            //ConfigureJwt(services);

            services.AddMvc().AddJsonOptions(options =>
            {
                //options.SerializerSettings.DateFormatString = "yyyyMMddHHmmss";
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });

            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });

            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<GzipCompressionProvider>();
            });

            services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionString")));

            //AddContext(services);
            AddServices(services);
            AddRepositories(services);
            //MapEntities();

            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI();
        }

        private void AddServices(IServiceCollection services)
        {
            services.AddScoped<SpaService, SpaService>();
        }

        private void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<ISpaRepository, SpaRepository>();
        }
    }
}
