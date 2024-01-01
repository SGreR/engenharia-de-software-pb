using System.ComponentModel.DataAnnotations.Schema;


namespace engenharia_de_software_pb.BLL.Models
{
    public class Notas
    {
        public int Id { get; set; }
        [ForeignKey("AlunoId")]
        public Aluno? Aluno { get; set; }
        public int AlunoId { get; set; }
        public NumeroTeste NumeroTeste { get; set; } = new NumeroTeste();
        public int? ReadingId { get; set; }
        public int? WritingId { get; set; }
        public int? ListeningId { get; set; }
        public int? GrammarId { get; set; }
        public int? SpeakingId { get; set; }
        public int? ClassPerformanceId { get; set; }
        [ForeignKey("ReadingId")]
        public Reading? Reading { get; set; }
        [ForeignKey("WritingId")]
        public Writing? Writing { get; set; }
        [ForeignKey("ListeningId")]
        public Listening? Listening { get; set; }
        [ForeignKey("GrammarId")]
        public Grammar? Grammar { get; set; }
        [ForeignKey("SpeakingId")]
        public Speaking? Speaking { get; set; }
        [ForeignKey("ClassPerformanceId")]
        public ClassPerformance? ClassPerformance { get; set; }
        public double MediaFinal => ObterMediaFinal();

        public double ObterMediaFinal()
        {
            double[] notas = new double[]{
                Reading == null ? 0 : Reading.Media,
                Writing == null ? 0 : Writing.Media,
                Listening == null ? 0 : Listening.Media,
                Grammar == null ? 0 : Grammar.Media,
                Speaking == null ? 0 : Speaking.Media,
                ClassPerformance == null ? 0 : ClassPerformance.Media
            };
            var media = Math.Round(notas.Average() * 10,2);
            return media;
        }

    }
}
