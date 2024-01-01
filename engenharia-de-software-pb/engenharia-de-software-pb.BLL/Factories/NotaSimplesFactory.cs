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
        public static T CreateNotaSimples(
            int Id = 0,
            int NotasId = 0,
            double primeiraNota = 0,
            double segundaNota = 0
            )
        {
            return new T
            {
                Id = Id,
                NotasId = NotasId,
                PrimeiraNota = primeiraNota,
                SegundaNota = segundaNota
            };
        }
    }
}
