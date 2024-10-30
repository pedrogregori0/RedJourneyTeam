using API_RedJourneyTeam.Data;
using API_RedJourneyTeam.Repositorios;
using API_RedJourneyTeam.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;

namespace API_RedJourneyTeam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.   

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();

            // Configure CORS to allow requests from any origin (you can restrict this to specific origins)
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder
                        .AllowAnyOrigin()   // Permite qualquer origem
                        .AllowAnyMethod()   // Permite qualquer método HTTP (GET, POST, PUT, DELETE, etc.)
                        .AllowAnyHeader()   // Permite qualquer cabeçalho
                );
            });


            builder.Services.AddEntityFrameworkMySQL()
                .AddDbContext<QuestionarioDBContext>(
                    options => options.UseMySQL(builder.Configuration.GetConnectionString("DataBase"))
                );

            builder.Services.AddScoped<IVisitantesInterface, VisitanteRepositorio>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Enable CORS
            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
