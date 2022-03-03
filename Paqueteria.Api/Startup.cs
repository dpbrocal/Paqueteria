using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Paqueteria.Models.Models;
using Paqueteria.Repositories.Common;
using Paqueteria.Repositories.ImplClasses;
using Paqueteria.Services.Common;
using Paqueteria.Services.ImplClasses;
using Paqueteria.Services.Interfaces;
using Paqueteria.Services.Security;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Paqueteria.Api
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
            services.AddDbContext<DBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Package.Api", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddMvc();
            services.AddOptions();
            var jwtSettings = Configuration.GetSection("JWTSettings");
            services.Configure<JWTSettings>(jwtSettings);

            var appSettings = jwtSettings.Get<JWTSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.SecretKey);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters{
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });


            var mapperConfig = new AutoMapper.MapperConfiguration(m =>
            {
                m.AddProfile<AutoMapping>();
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<ICarrierService, CarrierService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IDeliveryService, DeliveryService>();
            services.AddScoped<ILocationHistoryService, LocationHistoryService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<ILoginService, LoginService>();

            services.AddScoped(typeof(ICRUDRepository<>), typeof(CarrierRepository<>));
            services.AddScoped(typeof(ICRUDRepository<>), typeof(ClientRepository<>));
            services.AddScoped(typeof(ICRUDRepository<>), typeof(DeliveryRepository<>));
            services.AddScoped(typeof(ICRUDRepository<>), typeof(LocationRepository<>));
            services.AddScoped(typeof(ICRUDRepository<>), typeof(OrderRepository<>));
            services.AddScoped(typeof(ICRUDRepository<>), typeof(VehicleRepository<>));

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Package.Api v1"));
            }

            //app.UseMvc();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
