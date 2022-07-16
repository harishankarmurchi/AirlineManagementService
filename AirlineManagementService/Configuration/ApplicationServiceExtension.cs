using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Repository.Abstraction;
using Repository.Repos;
using Services.Abstraction;
using Services.Services;
using Services.Utility;
using System.Text;

namespace AirlineManagementService.Configuration
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddRequiredServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AirlineDbContext>(c =>
            {
                c.UseSqlServer(configuration.GetConnectionString("AppDbContext"));
                
            });

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //        .AddJwtBearer(c =>
            //        {
            //            c.TokenValidationParameters = new TokenValidationParameters
            //            {
            //                ValidateIssuer = true,
            //                ValidateAudience = true,
            //                ValidateLifetime = true,
            //                ValidateIssuerSigningKey = true,
            //                ValidIssuer = configuration["Jwt:Issuer"],
            //                ValidAudience = configuration["Jwt:Audience"],
            //                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:key"]))

            //            };
            //        });

            services.AddCors(c => {
                c.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader()
                                      .AllowCredentials().Build()
                );
            });
            services.AddApplicationDependency();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
        
        private static IServiceCollection AddApplicationDependency(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddTransient<IApplicationContext, ApplicationContext>();
            services.AddScoped<IMasterService, MasterService>();
            services.AddScoped<IMasterRepository, MasterRepository>();
            services.AddScoped<IAirlineService, AirlineService>();
            services.AddScoped<IAirlineRepository, AirlineRepository>();

            return services;
        }
    }
}
