using System.ComponentModel.DataAnnotations.Schema;


namespace engenharia_de_software_pb.BLL.Models
{
    public class Notas
    {
        public int Id { get; set; }
        [ForeignKey("AlunoId")]
        public Aluno? Aluno { get; set; }
        public int? AlunoId { get; set; }
        public NumeroTeste NumeroTeste { get; set; } = new NumeroTeste();
        public int? ReadingId { get; set; }
        public int? WritingId { get; set; }
        public int? ListeningId { get; set; }
        public int? GrammarId { get; set; }
        public int? SpeakingId { get; set; }
        public int? ClassPerformanceId { get; set; }
        public NotaSimples? Reading { get; set; } = new NotaSimples();
        public NotaSimples? Writing { get; set; } = new NotaSimples();
        public NotaSimples? Listening { get; set; } = new NotaSimples();
        public NotaSimples? Grammar { get; set; } = new NotaSimples();
        public Speaking? Speaking { get; set; } = new Speaking();
        public ClassPerformance? ClassPerformance { get; set; } = new ClassPerformance();


        public double ObterMediaPorHabilidade()
        {
            return 0.0;
        }

        public double ObterMediaFinal()
        {
            return 0.0;
        }

    }
}
