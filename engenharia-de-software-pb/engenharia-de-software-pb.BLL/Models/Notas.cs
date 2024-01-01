using System.ComponentModel.DataAnnotations.Schema;


namespace engenharia_de_software_pb.BLL.Models
{
    public class Notas
    {
        public int Id { get; set; }
        [ForeignKey("AlunoId")]
        public Aluno? Aluno { get; set; } = null;
        public int AlunoId { get; set; }
        public NumeroTeste NumeroTeste { get; set; } = new NumeroTeste();

        public Reading? Reading { get; set; } = null;
        public Writing? Writing { get; set; } = null;
        public Listening? Listening { get; set; } = null;
        public Grammar? Grammar { get; set; } = null;
        public Speaking? Speaking { get; set; } = null;
        public ClassPerformance? ClassPerformance { get; set; } = null;
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
