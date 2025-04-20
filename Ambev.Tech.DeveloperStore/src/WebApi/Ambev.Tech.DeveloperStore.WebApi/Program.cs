
using MediatR;
using AutoMapper;
using Ambev.Tech.DeveloperStore.Application;
using Ambev.Tech.DeveloperStore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

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

            // Adicionar MediatR e AutoMapper
            
            //builder.Services.AddMediatR(typeof(Program).Assembly);
            //builder.Services.AddAutoMapper(typeof(Program).Assembly);

            // Adicionar outros serviços, como EF Core, se necessário
            //builder.Services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
