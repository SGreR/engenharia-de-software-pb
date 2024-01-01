using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using engenharia_de_software_pb.BLL.Models;

namespace engenharia_de_software_pb.BLL.Factories
{
    public static class NotasFactory
    {
        public static Notas CreateNotas(
            Aluno aluno,
            NumeroTeste numeroTeste,
            Reading reading,
            Writing writing,
            Listening listening,
            Grammar grammar,
            Speaking speaking,
            ClassPerformance classPerformance)
        {
            return new Notas
            {
                Aluno = aluno,
                NumeroTeste = numeroTeste,
                Reading = reading,
                Writing = writing,
                Listening = listening,
                Grammar = grammar,
                Speaking = speaking,
                ClassPerformance = classPerformance
            };
        }
    }
}
