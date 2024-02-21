using System.ComponentModel.DataAnnotations.Schema;


namespace engenharia_de_software_pb.BLL.Models
{
    public class Notas
    {
        public int Id { get; set; }
        [ForeignKey("AlunoId")]
        public Aluno? Aluno { get; set; } = null;
        public int AlunoId { get; set; }
        public Turma? Turma { get; set; } = null;
        public int TurmaId { get; set; }
        public NumeroTeste NumeroTeste { get; set; } = new NumeroTeste();

        public Reading? Reading { get; set; } = new Reading();
        public Writing? Writing { get; set; } = new Writing();
        public Listening? Listening { get; set; } = new Listening();
        public Grammar? Grammar { get; set; } = new Grammar();
        public Speaking? Speaking { get; set; } = new Speaking();
        public ClassPerformance? ClassPerformance { get; set; } = new ClassPerformance();
        public double MediaFinal => ObterMediaFinal();

        protected double ObterMediaFinal()
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
