using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using engenharia_de_software_pb.BLL.Models;
using engenharia_de_software_pb.Data.Interfaces;

namespace engenharia_de_software_pb.Data.Repositories
{
    public class AlunoRepository : IRepository<Aluno>
    {
        public int Create(Aluno entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Aluno entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Aluno> GetAll()
        {
            throw new NotImplementedException();
        }

        public Aluno? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Aluno? GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Aluno Update(Aluno entity)
        {
            throw new NotImplementedException();
        }
    }
}
