using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using engenharia_de_software_pb.BLL.Models;

namespace engenharia_de_software_pb.BLL.Factories
{
    public static class NotaSimplesFactory<T> where T : NotaSimples, new()
    {
        public static T CreateNotaSimples(double primeiraNota = 0, double segundaNota = 0)
        {
            return new T
            {
                PrimeiraNota = primeiraNota,
                SegundaNota = segundaNota
            };
        }
    }
}
