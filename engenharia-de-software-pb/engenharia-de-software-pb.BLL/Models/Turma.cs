﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engenharia_de_software_pb.BLL.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Ano { get; set; } = 0;
        public Semestre Semestre { get; set; } = new Semestre();
        public Professor? Professor { get; set; }
        public int? ProfessorId { get; set; } = null;
        public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();
    }
}
