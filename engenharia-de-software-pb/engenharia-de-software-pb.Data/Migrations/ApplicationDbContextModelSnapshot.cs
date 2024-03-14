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

            modelBuilder.Entity("AlunoTurma", b =>
                {
                    b.Property<int>("AlunosId")
                        .HasColumnType("int");

                    b.Property<int>("TurmasId")
                        .HasColumnType("int");

                    b.HasKey("AlunosId", "TurmasId");

                    b.HasIndex("TurmasId");

                    b.ToTable("AlunoTurma", (string)null);
                });

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

                    b.ToTable("Alunos", (string)null);
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

                    b.HasIndex("NotasId")
                        .IsUnique();

                    b.ToTable("ClassPerformances", (string)null);
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

                    b.HasIndex("NotasId")
                        .IsUnique();

                    b.ToTable("Grammars", (string)null);
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

                    b.HasIndex("NotasId")
                        .IsUnique();

                    b.ToTable("Listenings", (string)null);
                });

            modelBuilder.Entity("engenharia_de_software_pb.BLL.Models.Notas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("NumeroTeste")
                        .HasColumnType("int");

                    b.Property<int>("TurmaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("TurmaId");

                    b.ToTable("Notas", (string)null);
                });

            modelBuilder.Entity("engenharia_de_software_pb.BLL.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Professores", (string)null);
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

                    b.HasIndex("NotasId")
                        .IsUnique();

                    b.ToTable("Readings", (string)null);
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

                    b.HasIndex("NotasId")
                        .IsUnique();

                    b.ToTable("Speakings", (string)null);
                });

            modelBuilder.Entity("engenharia_de_software_pb.BLL.Models.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProfessorId")
                        .HasColumnType("int");

                    b.Property<int>("Semestre")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Turmas", (string)null);
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

                    b.HasIndex("NotasId")
                        .IsUnique();

                    b.ToTable("Writings", (string)null);
                });

            modelBuilder.Entity("AlunoTurma", b =>
                {
                    b.HasOne("engenharia_de_software_pb.BLL.Models.Aluno", null)
                        .WithMany()
                        .HasForeignKey("AlunosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("engenharia_de_software_pb.BLL.Models.Turma", null)
                        .WithMany()
                        .HasForeignKey("TurmasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("engenharia_de_software_pb.BLL.Models.ClassPerformance", b =>
                {
                    b.HasOne("engenharia_de_software_pb.BLL.Models.Notas", null)
                        .WithOne("ClassPerformance")
                        .HasForeignKey("engenharia_de_software_pb.BLL.Models.ClassPerformance", "NotasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("engenharia_de_software_pb.BLL.Models.Grammar", b =>
                {
                    b.HasOne("engenharia_de_software_pb.BLL.Models.Notas", null)
                        .WithOne("Grammar")
                        .HasForeignKey("engenharia_de_software_pb.BLL.Models.Grammar", "NotasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("engenharia_de_software_pb.BLL.Models.Listening", b =>
                {
                    b.HasOne("engenharia_de_software_pb.BLL.Models.Notas", null)
                        .WithOne("Listening")
                        .HasForeignKey("engenharia_de_software_pb.BLL.Models.Listening", "NotasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("engenharia_de_software_pb.BLL.Models.Notas", b =>
                {
                    b.HasOne("engenharia_de_software_pb.BLL.Models.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("engenharia_de_software_pb.BLL.Models.Turma", "Turma")
                        .WithMany()
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("engenharia_de_software_pb.BLL.Models.Reading", b =>
                {
                    b.HasOne("engenharia_de_software_pb.BLL.Models.Notas", null)
                        .WithOne("Reading")
                        .HasForeignKey("engenharia_de_software_pb.BLL.Models.Reading", "NotasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("engenharia_de_software_pb.BLL.Models.Speaking", b =>
                {
                    b.HasOne("engenharia_de_software_pb.BLL.Models.Notas", null)
                        .WithOne("Speaking")
                        .HasForeignKey("engenharia_de_software_pb.BLL.Models.Speaking", "NotasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("engenharia_de_software_pb.BLL.Models.Turma", b =>
                {
                    b.HasOne("engenharia_de_software_pb.BLL.Models.Professor", "Professor")
                        .WithMany()
                        .HasForeignKey("ProfessorId");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("engenharia_de_software_pb.BLL.Models.Writing", b =>
                {
                    b.HasOne("engenharia_de_software_pb.BLL.Models.Notas", null)
                        .WithOne("Writing")
                        .HasForeignKey("engenharia_de_software_pb.BLL.Models.Writing", "NotasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("engenharia_de_software_pb.BLL.Models.Notas", b =>
                {
                    b.Navigation("ClassPerformance");

                    b.Navigation("Grammar");

                    b.Navigation("Listening");

                    b.Navigation("Reading");

                    b.Navigation("Speaking");

                    b.Navigation("Writing");
                });
#pragma warning restore 612, 618
        }
    }
}
