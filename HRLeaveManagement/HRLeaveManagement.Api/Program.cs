using HRLeaveManagement.Application;
using HRLeaveManagement.Infrastructure;
using HRLeaveManagement.Persistence;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace HRLeaveManagement.Api
{
    public class Program
    {
        //private static IConfiguration _configuration;
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Initialize _configuration with the builder's configuration
            IConfiguration _configuration = builder.Configuration;

            //builder.Services.AddDbContext<LeaveManagementDbContext>(options =>
            //{
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("LeaveManagementConnectionString"));
            //});
            //builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

            // All Layer are Register here
            builder.Services.ConfigureApplicationServices();
            builder.Services.ConfigureInfrastructureServices(_configuration);
            builder.Services.ConfigurePersistenceServices(_configuration);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "HR LeaveManagement Api", Version = "v1" });
            });

            // Added CorePolicy

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder
                        .AllowAnyOrigin()  // You can restrict this to specific origins if needed
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
            }
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HR.LeaveManagement.Api v1"));

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.MapControllers();

            app.Run();
        }
    }
}