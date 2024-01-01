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
            Aluno? aluno = null,
            int alunoId = 0,
            NumeroTeste numeroTeste = NumeroTeste.Primeiro,
            Reading? reading = null,
            int? readingId = null,
            Writing? writing = null,
            int? writingId  = null,
            Listening? listening = null,
            int? listeningId  = null,
            Grammar? grammar = null,
            int? grammarId  = null,
            Speaking? speaking = null,
            int? speakingId  = null,
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
                ReadingId = readingId,
                Writing = writing,
                WritingId = writingId,
                Listening = listening,
                ListeningId = listeningId,
                Grammar = grammar,
                GrammarId = grammarId,
                Speaking = speaking,
                SpeakingId = speakingId,
                ClassPerformance = classPerformance,
                ClassPerformanceId = classPerformanceId
            };
        }
    }
}
