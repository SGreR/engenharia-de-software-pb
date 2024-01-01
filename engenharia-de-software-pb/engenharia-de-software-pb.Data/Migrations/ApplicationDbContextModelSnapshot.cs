﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using engenharia_de_software_pb.Data;

#nullable disable

namespace engenharia_de_software_pb.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("engenharia_de_software_pb.BLL.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("engenharia_de_software_pb.BLL.Models.ClassPerformance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BehaviorGrade")
                        .HasColumnType("int");

                    b.Property<int>("HomeworkGrade")
                        .HasColumnType("int");

                    b.Property<int>("NotasId")
                        .HasColumnType("int");

                    b.Property<int>("ParticipationGrade")
                        .HasColumnType("int");

                    b.Property<int>("PresenceGrade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NotasId");

                    b.ToTable("ClassPerformances");
                });

            modelBuilder.Entity("engenharia_de_software_pb.BLL.Models.Grammar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("NotasId")
                        .HasColumnType("int");

                    b.Property<double>("PrimeiraNota")
                        .HasColumnType("float");

                    b.Property<double>("SegundaNota")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("NotasId");

                    b.ToTable("Grammars");
                });

            modelBuilder.Entity("engenharia_de_software_pb.BLL.Models.Listening", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("NotasId")
                        .HasColumnType("int");

                    b.Property<double>("PrimeiraNota")
                        .HasColumnType("float");

                    b.Property<double>("SegundaNota")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("NotasId");

                    b.ToTable("Listenings");
                });

            modelBuilder.Entity("engenharia_de_software_pb.BLL.Models.Notas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int?>("ClassPerformanceId")
                        .HasColumnType("int");

                    b.Property<int?>("GrammarId")
                        .HasColumnType("int");

                    b.Property<int?>("ListeningId")
                        .HasColumnType("int");

                    b.Property<int>("NumeroTeste")
                        .HasColumnType("int");

                    b.Property<int?>("ReadingId")
                        .HasColumnType("int");

                    b.Property<int?>("SpeakingId")
                        .HasColumnType("int");

                    b.Property<int?>("WritingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("ClassPerformanceId");

                    b.HasIndex("GrammarId");

                    b.HasIndex("ListeningId");

                    b.HasIndex("ReadingId");

                    b.HasIndex("SpeakingId");

                    b.HasIndex("WritingId");

                    b.ToTable("Notas");
                });

            modelBuilder.Entity("engenharia_de_software_pb.BLL.Models.Reading", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("NotasId")
                        .HasColumnType("int");

                    b.Property<double>("PrimeiraNota")
                        .HasColumnType("float");

                    b.Property<double>("SegundaNota")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("NotasId");

                    b.ToTable("Readings");
                });

            modelBuilder.Entity("engenharia_de_software_pb.BLL.Models.Speaking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccuracyGrade")
                        .HasColumnType("int");

                    b.Property<int>("L2Use")
                        .HasColumnType("int");

                    b.Property<int>("LanguageRangeGrade")
                        .HasColumnType("int");

                    b.Property<int>("NotasId")
                        .HasColumnType("int");

                    b.Property<int>("ProductionAndFluencyGrade")
                        .HasColumnType("int");

                    b.Property<int>("SpokenInteractionGrade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NotasId");

                    b.ToTable("Speakings");
                });

            modelBuilder.Entity("engenharia_de_software_pb.BLL.Models.Writing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("NotasId")
                        .HasColumnType("int");

                    b.Property<double>("PrimeiraNota")
                        .HasColumnType("float");

                    b.Property<double>("SegundaNota")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("NotasId");

                    b.ToTable("Writings");
                });

            modelBuilder.Entity("engenharia_de_software_pb.BLL.Models.ClassPerformance", b =>
                {
                    b.HasOne("engenharia_de_software_pb.BLL.Models.Notas", "Notas")
                        .WithMany()
                        .HasForeignKey("NotasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Notas");
                });

            modelBuilder.Entity("engenharia_de_software_pb.BLL.Models.Grammar", b =>
                {
                    b.HasOne("engenharia_de_software_pb.BLL.Models.Notas", "Notas")
                        .WithMany()
                        .HasForeignKey("NotasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Notas");
                });

            modelBuilder.Entity("engenharia_de_software_pb.BLL.Models.Listening", b =>
                {
                    b.HasOne("engenharia_de_software_pb.BLL.Models.Notas", "Notas")
                        .WithMany()
                        .HasForeignKey("NotasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Notas");
                });

            modelBuilder.Entity("engenharia_de_software_pb.BLL.Models.Notas", b =>
                {
                    b.HasOne("engenharia_de_software_pb.BLL.Models.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("engenharia_de_software_pb.BLL.Models.ClassPerformance", "ClassPerformance")
                        .WithMany()
                        .HasForeignKey("ClassPerformanceId");

                    b.HasOne("engenharia_de_software_pb.BLL.Models.Grammar", "Grammar")
                        .WithMany()
                        .HasForeignKey("GrammarId");

                    b.HasOne("engenharia_de_software_pb.BLL.Models.Listening", "Listening")
                        .WithMany()
                        .HasForeignKey("ListeningId");

                    b.HasOne("engenharia_de_software_pb.BLL.Models.Reading", "Reading")
                        .WithMany()
                        .HasForeignKey("ReadingId");

                    b.HasOne("engenharia_de_software_pb.BLL.Models.Speaking", "Speaking")
                        .WithMany()
                        .HasForeignKey("SpeakingId");

                    b.HasOne("engenharia_de_software_pb.BLL.Models.Writing", "Writing")
                        .WithMany()
                        .HasForeignKey("WritingId");

                    b.Navigation("Aluno");

                    b.Navigation("ClassPerformance");

                    b.Navigation("Grammar");

                    b.Navigation("Listening");

                    b.Navigation("Reading");

                    b.Navigation("Speaking");

                    b.Navigation("Writing");
                });

            modelBuilder.Entity("engenharia_de_software_pb.BLL.Models.Reading", b =>
                {
                    b.HasOne("engenharia_de_software_pb.BLL.Models.Notas", "Notas")
                        .WithMany()
                        .HasForeignKey("NotasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Notas");
                });

            modelBuilder.Entity("engenharia_de_software_pb.BLL.Models.Speaking", b =>
                {
                    b.HasOne("engenharia_de_software_pb.BLL.Models.Notas", "Notas")
                        .WithMany()
                        .HasForeignKey("NotasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Notas");
                });

            modelBuilder.Entity("engenharia_de_software_pb.BLL.Models.Writing", b =>
                {
                    b.HasOne("engenharia_de_software_pb.BLL.Models.Notas", "Notas")
                        .WithMany()
                        .HasForeignKey("NotasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Notas");
                });
#pragma warning restore 612, 618
        }
    }
}
