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
        public async void AtualizarAlunos(Turma turmaAntiga, Turma turmaAtualizada)
        {

            foreach (var aluno in turmaAntiga.Alunos.ToList())
            {
                if (!turmaAtualizada.Alunos.Any(a => a.Id == aluno.Id))
                {
                    turmaAntiga.Alunos.Remove(aluno);
                }
            }

            foreach (var aluno in turmaAtualizada.Alunos)
            {
                if (!turmaAntiga.Alunos.Any(a => a.Id == aluno.Id))
                {
                    turmaAntiga.Alunos.Add(aluno);
                }
            }

            foreach (var aluno in turmaAntiga.Alunos)
            {
                aluno.Turmas = null;
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
