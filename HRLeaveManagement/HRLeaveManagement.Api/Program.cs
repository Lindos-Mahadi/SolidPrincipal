using HRLeaveManagement.Application;
using HRLeaveManagement.Infrastructure;
using HRLeaveManagement.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HRLeaveManagement.Api
{
    public class Program
    {
        //private static IConfiguration _configuration;
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Initialize _configuration with the builder's configuration
            //IConfiguration _configuration = builder.Configuration;

            //builder.Services.AddDbContext<LeaveManagementDbContext>(options =>
            //{
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("LeaveManagementConnectionString"));
            //});

            // All Layer are Register here
            builder.Services.ConfigureApplicationServices();
            builder.Services.ConfigureInfrastructureServices(builder.Configuration);
            builder.Services.ConfigurePersistenceServices(builder.Configuration);


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.MapControllers();

            app.Run();
        }
    }
}