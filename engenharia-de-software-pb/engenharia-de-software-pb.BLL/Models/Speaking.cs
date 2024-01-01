using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engenharia_de_software_pb.BLL.Models
{
    public class Speaking
    {
        public int Id { get; set; }
        public int NotasId { get; set; }
        [ForeignKey("NotasId")]
        public Notas? Notas { get; set; }
        [Range(0, 5)]
        public int ProductionAndFluencyGrade { get; set; } = 0;
        [Range(0, 5)]
        public int SpokenInteractionGrade { get; set; } = 0;
        [Range(0, 5)]
        public int LanguageRangeGrade { get; set; } = 0;
        [Range(0, 5)]
        public int AccuracyGrade { get; set; } = 0;
        [Range(0, 5)]
        public int L2Use { get; set; } = 0;
        public double Media => ObterMedia();

        protected double ObterMedia()
        {
            var notas = new int[] { ProductionAndFluencyGrade, SpokenInteractionGrade, LanguageRangeGrade, AccuracyGrade };
            double notaFinal = notas.Sum() * 5;
            var multiplier = (5 - L2Use) * 0.15;
            notaFinal = notaFinal - (notaFinal * multiplier);
 
            return notaFinal / 10;
        }
    }
}
