using System;
using System.Collections.Generic;
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

        public Aluno(string name)
        {
            Name = name;
        }
    }
}
