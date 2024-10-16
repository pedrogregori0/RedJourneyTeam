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

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkMySQL()
                .AddDbContext<QuestionarioDBContext>(
                    options => options.UseMySQL(builder.Configuration.GetConnectionString("DataBase"))
                );

            builder.Services.AddScoped<IVisitantesInterface, VisitanteRepositorio > ();

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
