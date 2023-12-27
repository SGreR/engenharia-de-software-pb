using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using engenharia_de_software_pb.BLL.Models;
using Microsoft.EntityFrameworkCore;

namespace engenharia_de_software_pb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notas>()
                .HasOne(n => n.Reading)
                .WithMany()
                .HasForeignKey(n => n.ReadingId);

            modelBuilder.Entity<Notas>()
                .HasOne(n => n.Writing)
                .WithMany()
                .HasForeignKey(n => n.WritingId);

            modelBuilder.Entity<Notas>()
                .HasOne(n => n.Listening)
                .WithMany()
                .HasForeignKey(n => n.ListeningId);

            modelBuilder.Entity<Notas>()
                .HasOne(n => n.Grammar)
                .WithMany()
                .HasForeignKey(n => n.GrammarId);

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Notas>? Notas { get; set; }
        public DbSet<NotaSimples>? NotaSimples { get; set; }
        public DbSet<Aluno>? Alunos { get; set; }
        public DbSet<Speaking>? Speakings { get; set; }
        public DbSet<ClassPerformance>? ClassPerformances { get; set; }
    }
}
