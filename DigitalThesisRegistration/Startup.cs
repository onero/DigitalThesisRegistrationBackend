using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalThesisRegistration
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            Environment = env;
        }

        private IHostingEnvironment Environment { get; }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Configure context
            services.AddSingleton(Configuration);
            //if (Environment.IsDevelopment())
            //    services.AddDbContext<DTRContext>(opt => opt.UseInMemoryDatabase("DTR"));
            //else
            //    services.AddDbContext<DTRContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Add Dependencies
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            // Add cors for Angular
            app.UseCors(builder => builder.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseMvc();
        }
    }
}