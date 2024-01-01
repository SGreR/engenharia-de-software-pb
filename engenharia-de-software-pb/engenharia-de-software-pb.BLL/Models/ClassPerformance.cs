using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engenharia_de_software_pb.BLL.Models
{
    public class ClassPerformance
    {
        public int Id { get; set; }

        public int NotasId { get; set; }
        [ForeignKey("NotasId")]
        public Notas? Notas { get; set; }

        [Range(0, 5)]
        public int PresenceGrade { get; set; } = 0;
        [Range(0, 5)]
        public int HomeworkGrade { get; set; } = 0;
        [Range(0, 5)]
        public int ParticipationGrade { get; set; } = 0;
        [Range(0, 5)]
        public int BehaviorGrade { get; set; } = 0; 
        public double Media => ObterMedia();

        protected double ObterMedia()
        {
            var notas = new int[] { PresenceGrade, HomeworkGrade, ParticipationGrade, BehaviorGrade };
            double media = notas.Sum() / 2;
            return media;
        }
    }
}
