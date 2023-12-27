using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engenharia_de_software_pb.Data.Interfaces
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetAll();
        public T? GetById(int id);
        public T? GetById(string id);
        public int Create(T entity);
        public T Update(T entity);
        public bool Delete(T entity);
        public bool DeleteById(int id);
    }
}
