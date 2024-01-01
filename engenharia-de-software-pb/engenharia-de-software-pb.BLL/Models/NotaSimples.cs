using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engenharia_de_software_pb.BLL.Models
{
    public class NotaSimples
    {
        public int Id { get; set; }

        public int NotasId { get; set; } = 0;
        [ForeignKey("NotasId")]
        public Notas? Notas { get; set; }

        [Range(0.0,10.0)]
        public double PrimeiraNota { get; set; } = 0.0;
        [Range(0.0, 10.0)]
        public double SegundaNota { get; set; } = 0.0;
        public double Media => ObterMedia();


        protected double ObterMedia()
        {
            return new double[] { PrimeiraNota, SegundaNota }.Average();
        }
    }
}
