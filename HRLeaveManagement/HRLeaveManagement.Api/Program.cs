using HRLeaveManagement.Application;
using HRLeaveManagement.Infrastructure;
using HRLeaveManagement.Persistence;

namespace HRLeaveManagement.Api
{
    public class Program
    {
        private static IConfiguration _configuration;
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // All Layer are Register here
            builder.Services.ConfigureApplicationServices();
            builder.Services.ConfigureInfrastructureServices(_configuration);
            builder.Services.ConfigurePersistenceServices(_configuration);


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