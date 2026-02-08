using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceLigueHockey.Data.Models;

namespace ServiceLigueHockey.Data.Configuration
{
    public class CalendrierConfiguration : IEntityTypeConfiguration<CalendrierBd>
    {
        public void Configure(EntityTypeBuilder<CalendrierBd> builder)
        {
            builder.ToTable("Calendrier");
            builder.HasKey("IdPartie");
            builder.Property(e => e.IdPartie).ValueGeneratedNever();
            builder.HasOne("zeAnnee").WithMany("listeParties")
                                     .HasForeignKey("AnneeStats")
                                     .OnDelete(DeleteBehavior.NoAction);
            builder.HasIndex(u => new { u.IdEquipeHote, u.IdEquipeVisiteuse, u.DatePartieJouee })
                   .IsUnique();
            builder.HasOne("EquipeHote").WithMany("listeEquipeHote")
                                        .HasForeignKey("IdEquipeHote")
                                        .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne("EquipeVisiteuse").WithMany("listeEquipeVisiteur")
                                             .HasForeignKey("IdEquipeVisiteuse")
                                             .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany("listePointeurs").WithOne("MonCalendrier")
                                             .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany("listePenalites").WithOne("MonCalendrier")
                                             .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                    new CalendrierBd { IdPartie = 1, IdEquipeHote = 1, IdEquipeVisiteuse = 2, AnneeStats = 2024, DatePartieJouee = new DateTime(2024, 10, 5, 20, 0, 0)}
                );
        }
    }
}