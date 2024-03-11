using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using engenharia_de_software_pb.BLL.Models;
using engenharia_de_software_pb.Data.Migrations;
using Microsoft.EntityFrameworkCore;

namespace engenharia_de_software_pb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Notas>? Notas { get; set; }
        public DbSet<Reading>? Readings { get; set; }
        public DbSet<Listening>? Listenings { get; set; }
        public DbSet<Writing>? Writings { get; set; }
        public DbSet<Grammar> Grammars { get; set; }
        public DbSet<Aluno>? Alunos { get; set; }
        public DbSet<Speaking>? Speakings { get; set; }
        public DbSet<ClassPerformance>? ClassPerformances { get; set; }
        public DbSet<Turma>? Turmas { get; set;}
        public DbSet<Professor>? Professores { get; set; }
    }
}
