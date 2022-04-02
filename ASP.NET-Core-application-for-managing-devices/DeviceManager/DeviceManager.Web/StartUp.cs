namespace DeviceManager.Web
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.OpenApi.Models;
    using DeviceManager.Data;
    using DeviceManager.Data.Repositories;
    using DeviceManager.Business.Services;
  
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
            services.AddControllers();

            services.AddDbContext<DeviceManagerDbContext>(options => options
               .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<DbInitializer>();

            services.AddScoped<IDeviceManagerRepository, DeviceManagerRepository>();
            services.AddScoped<IDeviceManagerService, DeviceManagerService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DeviceManager", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DeviceManager v1"));
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
