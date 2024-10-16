using API_RedJourneyTeam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace API_RedJourneyTeam.Data.Map
{
    public class VisitanteMap : IEntityTypeConfiguration<VisitantesQuestionario>
    {
        public void Configure(EntityTypeBuilder<VisitantesQuestionario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).HasMaxLength(255);
            builder.Property(x => x.RespostaPergunta1).IsRequired().HasMaxLength(50);
            builder.Property(x => x.RespostaPergunta2).IsRequired().HasMaxLength(50);
            builder.Property(x => x.RespostaPergunta3).IsRequired().HasMaxLength(50);
            builder.Property(x => x.SugestaoTema).HasMaxLength(500);


        }
    }
}
