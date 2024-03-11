using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using engenharia_de_software_pb.BLL.Models;
using Newtonsoft.Json;

namespace engenharia_de_software_pb.Data.Services
{
    public class AlunosService
    {
        public void AtualizarAlunos(Turma turmaAntiga, Turma turmaAtualizada)
        {
            foreach (var aluno in turmaAtualizada.Alunos)
            {
                var existingAluno = turmaAntiga.Alunos.FirstOrDefault(a => a.Id == aluno.Id);
                if (existingAluno != null)
                {
                    existingAluno.Id = aluno.Id;
                    existingAluno.Name = aluno.Name;
                    existingAluno.Turmas = null;
                }
                else
                {
                    turmaAntiga.Alunos.Add(aluno);
                }
            }

            var alunosToRemove = turmaAntiga.Alunos
                .Where(aluno => !turmaAtualizada.Alunos.Any(a => a.Id == aluno.Id))
                .ToList();

            foreach (var alunoToRemove in alunosToRemove)
            {
                turmaAntiga.Alunos.Remove(alunoToRemove);
            }

            foreach (var aluno in turmaAntiga.Alunos)
            {
                aluno.Turmas = null;
            }
        }

        public void AtualizarTurmas(Aluno alunoAntigo, Aluno novoAluno)
        {
            foreach (var turma in alunoAntigo.Turmas.ToList())
            {
                if (!novoAluno.Turmas.Any(t => t.Id == turma.Id))
                {
                    alunoAntigo.Turmas.Remove(turma);
                }
            }

            foreach (var turma in novoAluno.Turmas)
            {
                if (!alunoAntigo.Turmas.Any(t => t.Id == turma.Id))
                {
                    alunoAntigo.Turmas.Add(turma);
                }
            }
        }

        private async Task<ICollection<Aluno>> GetAlunos(IEnumerable<int> idList)
        {
            ICollection<Aluno> alunos = null;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string idListString = string.Join("&", idList.Select(id => $"ids={id}"));

                    string requestUrl = $"https://localhost:7245/api/Alunos/GetMultipleById?{idListString}";

                    HttpResponseMessage response = await client.GetAsync(requestUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = await response.Content.ReadAsStringAsync();

                        alunos = JsonConvert.DeserializeObject<ICollection<Aluno>>(jsonContent);
                    }
                    else
                    {
                        Console.WriteLine($"Failed to retrieve data. Status code: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return alunos;
        }
    }
}
