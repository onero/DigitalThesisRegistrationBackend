using System;
using System.IO;
using DigitalThesisRegistration.Helpers;
using DTRBLL.Services;
using DTRBLL.Services.Implementations;
using DTRDAL.Context;
using DTRDAL.UOW;
using DTRDAL.UOW.Implementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace DigitalThesisRegistration
{
    public class Startup
    {
        private IHostingEnvironment Environment { get; }

        private IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            // Build configuration with appsettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            JwtSecurityKey.SetSecret("a secret that needs to be at least 16 characters long");
            // Define Environment
            Environment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Add JWT based authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = JwtSecurityKey.Key,
                    ValidateLifetime = true, //validate the expiration and not before values in the token
                    ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
                };
            });

            // Configure context
            services.AddSingleton(Configuration);
            if (Environment.IsDevelopment())
                services.AddDbContext<DTRContext>(opt => opt.UseInMemoryDatabase("DTR"));
            else
                services.AddDbContext<DTRContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Add Dependencies
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ISupervisorService, SupervisorService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IContractService, ContractService>();
            services.AddScoped<IContractGridService, ContractGridService>();

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "DigitalThesisRegistration.xml");
                c.IncludeXmlComments(xmlPath);
            });

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

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            // Use authentication
            app.UseAuthentication();


            app.UseMvc();
        }
    }
}