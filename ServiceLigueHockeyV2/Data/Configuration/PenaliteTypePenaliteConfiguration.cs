using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceLigueHockey.Data.Models;

namespace ServiceLigueHockey.Data.Configuration
{
    public class PenaliteTypePenaliteConfiguration : IEntityTypeConfiguration<Penalite_TypePenaliteBd>
    {
        public void Configure(EntityTypeBuilder<Penalite_TypePenaliteBd> builder)
        {
            builder.ToTable("Penalite_TypePenalite");
            builder.HasKey("IdPenalite");
            builder.Property(e => e.IdPenalite).ValueGeneratedNever();
            builder.HasOne("typePenalitesParent")
                   .WithMany("listePenTypePen")
                   .HasForeignKey("IdTypePenalite");
            builder.HasOne("penaliteParent")
                   .WithMany("listePenalites")
                   .HasForeignKey("MomentDelaPenalite", "IdJoueurPenalise");
        }
    }
}