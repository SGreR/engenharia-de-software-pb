using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engenharia_de_software_pb.BLL.Models
{
    public class Speaking : Habilidade
    {
        public int ProductionAndFluencyGrade { get; set; } = 0;
        public int SpokenInteractionGrade { get; set; } = 0;
        public int LanguageRangeGrade { get; set; } = 0;
        public int AccuracyGrade { get; set; } = 0;
        public int L2Use { get; set; } = 0;
        public double FinalScore => ObterMedia();

        protected override double ObterMedia()
        {
            var notas = new int[] { ProductionAndFluencyGrade, SpokenInteractionGrade, LanguageRangeGrade, AccuracyGrade };
            double notaFinal = notas.Sum() * 5;
            var multiplier = (5 - L2Use) * 0.15;
            notaFinal = notaFinal - (notaFinal * multiplier);
 
            return notaFinal;
        }
    }
}
