
using API_RedJourneyTeam.Data.Map;
using API_RedJourneyTeam.Models;
using Microsoft.EntityFrameworkCore;

namespace API_RedJourneyTeam.Data
{
    public class QuestionarioDBContext : DbContext
    {
        public QuestionarioDBContext(DbContextOptions<QuestionarioDBContext> options)
            : base(options)
        {   
        }
        public DbSet<VisitantesQuestionario> Visitantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VisitanteMap());

            base.OnModelCreating(modelBuilder);
        }

    }

}
