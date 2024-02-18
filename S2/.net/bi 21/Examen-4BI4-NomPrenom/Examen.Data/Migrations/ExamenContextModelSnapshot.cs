﻿// <auto-generated />
using System;
using Examen.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Examen.Data.Migrations
{
    [DbContext(typeof(ExamenContext))]
    partial class ExamenContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Examen.Domain.Entities.Cagnotte", b =>
                {
                    b.Property<int>("CagnotteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateLimite")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EntrepriseId")
                        .HasColumnType("int");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SommeDemandée")
                        .HasColumnType("int");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("CagnotteId");

                    b.HasIndex("EntrepriseId");

                    b.ToTable("Cagnottes");
                });

            modelBuilder.Entity("Examen.Domain.Entities.Entreprise", b =>
                {
                    b.Property<int>("EntrepriseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdresseEntreprise")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MailEntreprise")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomEntreprise")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntrepriseId");

                    b.ToTable("Entreprises");
                });

            modelBuilder.Entity("Examen.Domain.Entities.Participant", b =>
                {
                    b.Property<int>("ParticipantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MailParticipant")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ParticipantId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("Examen.Domain.Entities.Participation", b =>
                {
                    b.Property<int>("CagnotteFk")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantFk")
                        .HasColumnType("int");

                    b.Property<int?>("CagnotteId")
                        .HasColumnType("int");

                    b.Property<int>("Montant")
                        .HasColumnType("int");

                    b.Property<int?>("ParticipantId")
                        .HasColumnType("int");

                    b.HasKey("CagnotteFk", "ParticipantFk");

                    b.HasIndex("CagnotteId");

                    b.HasIndex("ParticipantId");

                    b.ToTable("Participations");
                });

            modelBuilder.Entity("Examen.Domain.Entities.Cagnotte", b =>
                {
                    b.HasOne("Examen.Domain.Entities.Entreprise", "Entreprise")
                        .WithMany("Cagnottes")
                        .HasForeignKey("EntrepriseId");

                    b.Navigation("Entreprise");
                });

            modelBuilder.Entity("Examen.Domain.Entities.Participation", b =>
                {
                    b.HasOne("Examen.Domain.Entities.Cagnotte", "Cagnotte")
                        .WithMany("Participations")
                        .HasForeignKey("CagnotteId");

                    b.HasOne("Examen.Domain.Entities.Participant", "Participant")
                        .WithMany("Participations")
                        .HasForeignKey("ParticipantId");

                    b.Navigation("Cagnotte");

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("Examen.Domain.Entities.Cagnotte", b =>
                {
                    b.Navigation("Participations");
                });

            modelBuilder.Entity("Examen.Domain.Entities.Entreprise", b =>
                {
                    b.Navigation("Cagnottes");
                });

            modelBuilder.Entity("Examen.Domain.Entities.Participant", b =>
                {
                    b.Navigation("Participations");
                });
#pragma warning restore 612, 618
        }
    }
}
