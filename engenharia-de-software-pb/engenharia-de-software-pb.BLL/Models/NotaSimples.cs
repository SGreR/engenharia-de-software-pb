using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engenharia_de_software_pb.BLL.Models
{
    public class NotaSimples : Habilidade
    {
        public double PrimeiraNota { get; set; } = 0.0;
        public double SegundaNota { get; set; } = 0.0;


        protected override double ObterMedia()
        {
            return PrimeiraNota + SegundaNota / 2;
        }
    }
}
