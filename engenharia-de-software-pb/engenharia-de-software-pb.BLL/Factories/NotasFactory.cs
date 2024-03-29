﻿using System;
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
            Aluno? aluno = null,
            int alunoId = 0,
            NumeroTeste numeroTeste = NumeroTeste.Primeiro,
            Reading? reading = null,
            Writing? writing = null,
            Listening? listening = null,
            Grammar? grammar = null,
            Speaking? speaking = null,
            ClassPerformance? classPerformance = null,
            int? classPerformanceId  = null
            )
        {
            return new Notas
            {
                Aluno = aluno,
                AlunoId = alunoId,
                NumeroTeste = numeroTeste,
                Reading = reading,
                Writing = writing,
                Listening = listening,
                Grammar = grammar,
                Speaking = speaking,
                ClassPerformance = classPerformance,
            };
        }
    }
}
