using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using engenharia_de_software_pb.BLL.Models;

namespace engenharia_de_software_pb.BLL.Factories
{
    public static class NotaSimplesFactory
    {
        public static NotaSimples CreateNotaSimples(double primeiraNota, double segundaNota)
        {
            return new NotaSimples
            {
                PrimeiraNota = primeiraNota,
                SegundaNota = segundaNota
            };
        }
    }
}
