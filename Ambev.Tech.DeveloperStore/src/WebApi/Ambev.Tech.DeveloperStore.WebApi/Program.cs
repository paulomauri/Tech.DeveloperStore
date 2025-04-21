
using MediatR;
using AutoMapper;
using Ambev.Tech.DeveloperStore.Application;
using Ambev.Tech.DeveloperStore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Ambev.Tech.DeveloperStore.Infrastructure.Extensions;
using Microsoft.IdentityModel.Tokens;
using Ambev.Tech.DeveloperStore.Application.MappingProfiles;
using System.Text;
using Ambev.Tech.DeveloperStore.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ambev.Tech.DeveloperStore.Infrastructure.Settings;
using Ambev.Tech.DeveloperStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Ambev.Tech.DeveloperStore.Application.Behaviors;
using Ambev.Tech.DeveloperStore.WebApi.Middlewares;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Ambev.Tech.DeveloperStore.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Registrar a infraestrurura
            builder.Services.AddInfrastructure();

            // Adicionar MediatR 
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Adicionar o AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // Adicionar outros serviços, como EF Core, se necessário
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
            builder.Services.AddSingleton<JwtTokenGenerator>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();
                var key = Encoding.ASCII.GetBytes(jwtSettings.SecretKey);

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidateAudience = true,
                    ValidAudience = jwtSettings.Audience,
                    ValidateLifetime = true
                };
            });

            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            // Adiciona os serviços ao contêiner
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DeveloperStore API", Version = "v1" });

                // Para incluir comentários de documentação XML (opcional, mas recomendado)
                var xmlFile = Path.Combine(AppContext.BaseDirectory, "Ambev.Tech.DeveloperStore.WebApi.xml");
                c.IncludeXmlComments(xmlFile);
            });

            builder.Services.AddControllers();

            var app = builder.Build();
            
            app.UseMiddleware<ExceptionHandlingMiddleware>(); 

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(); // Gera a documentação Swagger
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "DeveloperStore API v1");
                    c.RoutePrefix = string.Empty; 
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

    }
}
