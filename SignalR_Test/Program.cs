
using Microsoft.Extensions.Options;
using SignalR_Test.Model;

namespace SignalR_Test
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
            builder.Services.AddSignalR();
            builder.Services.AddCors(op =>
            {
                op.AddDefaultPolicy(policy =>
                {

                    policy.WithOrigins("http://localhost:4200") // Allow Angular's local development URL
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();

                });
            });
                var app = builder.Build();

                app.UseCors();
                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseAuthorization();

                app.MapHub<ChatHub>("/chatHub");
                app.MapControllers();

                app.Run();
            }
    }
    } 
