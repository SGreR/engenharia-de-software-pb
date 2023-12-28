using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using engenharia_de_software_pb.BLL.Models;

namespace engenharia_de_software_pb.BLL.Factories
{
    public static class AlunoFactory
    {
        public static Aluno CreateAluno(string name)
        {
            return new Aluno()
            {
                Name = name
            };
        }

        public static void PopularNotas(this Aluno aluno, IEnumerable<Notas> notas)
        {
            aluno.Notas = notas.ToList();
        }

    }
}
