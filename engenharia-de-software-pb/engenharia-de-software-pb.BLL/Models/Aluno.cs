using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engenharia_de_software_pb.BLL.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Notas>? Notas { get; set; } = new List<Notas>();
        public ICollection<Turma> Turmas { get; set; } = new List<Turma>();

    }
}
