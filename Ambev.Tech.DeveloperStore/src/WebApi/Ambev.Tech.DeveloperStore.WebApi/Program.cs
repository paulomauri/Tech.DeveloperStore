
using MediatR;
using AutoMapper;
using Ambev.Tech.DeveloperStore.Application;
using Ambev.Tech.DeveloperStore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Ambev.Tech.DeveloperStore.Infrastructure.Extensions;
using Microsoft.IdentityModel.Tokens;
using Ambev.Tech.DeveloperStore.Application.MappingProfiles;
using System.Text;

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

            // Adicionar MediatR e AutoMapper

            //builder.Services.AddMediatR(typeof(Program).Assembly);

            // Registre o AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // Adicionar outros serviços, como EF Core, se necessário
            //builder.Services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    var config = builder.Configuration;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = config["Jwt:Issuer"],
                        ValidAudience = config["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"])),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

    }
}
