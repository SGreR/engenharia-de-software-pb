using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using engenharia_de_software_pb.BLL.Models;
using engenharia_de_software_pb.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace engenharia_de_software_pb.Data.Services
{
    public class TurmasService
    {
        public void AtualizarTurma(ApplicationDbContext context, Turma turmaAtual, Turma turmaAntiga)
        {
            var tracker = context.ChangeTracker.Entries();
            var alunosToAdd = turmaAtual.Alunos.Where(a => !turmaAntiga.Alunos.Any(aluno => aluno.Id == a.Id)).ToList();
            var alunosToKeep = turmaAtual.Alunos.Where(a => turmaAntiga.Alunos.Any(aluno => aluno.Id == a.Id)).ToList();
            var alunosToRemove = turmaAntiga.Alunos.Where(a => !turmaAtual.Alunos.Any(aluno => aluno.Id == a.Id)).ToList();

            foreach (var entry in tracker)
            {
                if (entry.Entity is Dictionary<string, object> dictionary)
                {
                    var alunoId = dictionary["AlunosId"];
                    var turmaId = dictionary["TurmasId"];
                    if (alunosToKeep.Any(a => a.Id == (int)alunoId))
                    {
                        entry.State = EntityState.Unchanged;
                        tracker = context.ChangeTracker.Entries();
                    }

                    tracker = context.ChangeTracker.Entries();
                }

            }
        }
    }
}
