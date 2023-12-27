using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engenharia_de_software_pb.BLL.Models
{
    public abstract class Habilidade
    {
        public int Id { get; set; }
        public int NotasId { get; set; }
        [ForeignKey("NotasId")]
        public Notas Notas { get; set; }

        protected abstract double ObterMedia();

    }
}
