using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engenharia_de_software_pb.BLL.Models
{
    public class NotaSimples : Habilidade
    {
        [Range(0.0,10.0)]
        public double PrimeiraNota { get; set; } = 0.0;
        [Range(0.0, 10.0)]
        public double SegundaNota { get; set; } = 0.0;


        protected override double ObterMedia()
        {
            return PrimeiraNota + SegundaNota / 2;
        }
    }
}
