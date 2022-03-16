using API.Services.Catalog.Categories;
using API.Services.Catalog.ExportDetails;
using API.Services.Catalog.Exports;
using API.Services.Catalog.ImportDetails;
using API.Services.Catalog.Imports;
using API.Services.Catalog.Products;
using API.Services.Catalog.Units;
using Inventory.Data.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Inventory
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
            //Declare Connection DbContext
            services.AddDbContext<InventoryDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("InventoryDb")));

            //services.AddIdentity<AppUser, AppRole>()
            //    .AddEntityFrameworkStores<InventoryDbContext>()
            //    .AddDefaultTokenProviders();
            //Declare DI
            services.AddTransient<IUnitServices, UnitServices>();
            services.AddTransient<ICategoryServices, CategoryServices>();
            services.AddTransient<IProductServices, ProductServices>();
            services.AddTransient<IImportServices, ImportServices>();
            services.AddTransient<IExportServices, ExportServices>();
            services.AddTransient<IImportDetailServices, ImportDetailServices>();
            services.AddTransient<IExportDetailServices, ExportDetailServices>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "InventoryAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Inventory v1"));
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