﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServiceLigueHockey.Data;

#nullable disable

namespace ServiceLigueHockeyV2.Data.Migrations
{
    [DbContext(typeof(ServiceLigueHockeyContext))]
    [Migration("20220822182553_AjoutDonnees14h25")]
    partial class AjoutDonnees14h25
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ServiceLigueHockey.Data.Models.EquipeBd", b =>
                {
                    b.Property<int>("EquipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AnneeDebut")
                        .HasColumnType("int");

                    b.Property<int?>("AnneeFin")
                        .HasColumnType("int");

                    b.Property<int?>("EstDevenueEquipe")
                        .HasColumnType("int");

                    b.Property<string>("NomEquipe")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("EquipeId");

                    b.ToTable("Equipe", (string)null);
                });

            modelBuilder.Entity("ServiceLigueHockey.Data.Models.EquipeJoueurBd", b =>
                {
                    b.Property<int>("EquipeFK")
                        .HasColumnType("int");

                    b.Property<int>("JoueurFK")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDebutAvecEquipe")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateFinAvecEquipe")
                        .HasColumnType("datetime(6)");

                    b.Property<short>("NoDossard")
                        .HasColumnType("smallint");

                    b.Property<int>("equipeBdEquipeId")
                        .HasColumnType("int");

                    b.Property<int>("joueurBdJoueurId")
                        .HasColumnType("int");

                    b.HasKey("EquipeFK", "JoueurFK", "DateDebutAvecEquipe");

                    b.HasIndex("equipeBdEquipeId");

                    b.HasIndex("joueurBdJoueurId");

                    b.ToTable("EquipeJoueur", (string)null);
                });

            modelBuilder.Entity("ServiceLigueHockey.Data.Models.JoueurBd", b =>
                {
                    b.Property<int>("JoueurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PaysOrigine")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("VilleNaissance")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("JoueurId");

                    b.ToTable("Joueur", (string)null);
                });

            modelBuilder.Entity("ServiceLigueHockey.Data.Models.StatsJoueurBd", b =>
                {
                    b.Property<int>("JoueurFK")
                        .HasColumnType("int");

                    b.Property<int>("EquipeFK")
                        .HasColumnType("int");

                    b.Property<short>("AnneeStats")
                        .HasColumnType("smallint");

                    b.Property<int>("ButsAlloues")
                        .HasColumnType("int");

                    b.Property<short>("Defaites")
                        .HasColumnType("smallint");

                    b.Property<short>("DefaitesEnProlongation")
                        .HasColumnType("smallint");

                    b.Property<double>("MinutesJouees")
                        .HasColumnType("double");

                    b.Property<short>("NbButs")
                        .HasColumnType("smallint");

                    b.Property<short>("NbMinutesPenalites")
                        .HasColumnType("smallint");

                    b.Property<short>("NbPartiesJouees")
                        .HasColumnType("smallint");

                    b.Property<short>("NbPasses")
                        .HasColumnType("smallint");

                    b.Property<short>("NbPoints")
                        .HasColumnType("smallint");

                    b.Property<short>("Nulles")
                        .HasColumnType("smallint");

                    b.Property<short>("PlusseMoins")
                        .HasColumnType("smallint");

                    b.Property<int>("TirsAlloues")
                        .HasColumnType("int");

                    b.Property<short>("Victoires")
                        .HasColumnType("smallint");

                    b.Property<int>("equipeBdEquipeId")
                        .HasColumnType("int");

                    b.HasKey("JoueurFK", "EquipeFK", "AnneeStats");

                    b.HasIndex("equipeBdEquipeId");

                    b.ToTable("StatsJoueur", (string)null);
                });

            modelBuilder.Entity("ServiceLigueHockey.Data.Models.EquipeJoueurBd", b =>
                {
                    b.HasOne("ServiceLigueHockey.Data.Models.EquipeBd", "equipeBd")
                        .WithMany("listeEquipeJoueur")
                        .HasForeignKey("equipeBdEquipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServiceLigueHockey.Data.Models.JoueurBd", "joueurBd")
                        .WithMany("listeEquipeJoueur")
                        .HasForeignKey("joueurBdJoueurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("equipeBd");

                    b.Navigation("joueurBd");
                });

            modelBuilder.Entity("ServiceLigueHockey.Data.Models.StatsJoueurBd", b =>
                {
                    b.HasOne("ServiceLigueHockey.Data.Models.JoueurBd", "Joueur")
                        .WithMany("listeStatsJoueur")
                        .HasForeignKey("JoueurFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServiceLigueHockey.Data.Models.EquipeBd", "equipeBd")
                        .WithMany()
                        .HasForeignKey("equipeBdEquipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Joueur");

                    b.Navigation("equipeBd");
                });

            modelBuilder.Entity("ServiceLigueHockey.Data.Models.EquipeBd", b =>
                {
                    b.Navigation("listeEquipeJoueur");
                });

            modelBuilder.Entity("ServiceLigueHockey.Data.Models.JoueurBd", b =>
                {
                    b.Navigation("listeEquipeJoueur");

                    b.Navigation("listeStatsJoueur");
                });
#pragma warning restore 612, 618
        }
    }
}
