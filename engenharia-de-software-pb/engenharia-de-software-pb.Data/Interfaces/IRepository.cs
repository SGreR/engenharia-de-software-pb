using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engenharia_de_software_pb.Data.Interfaces
{
    public interface IRepository<T>
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T?> GetById(int id);
        public Task<IEnumerable<T>> GetByRelatedId(string type, int id);
        public Task<IEnumerable<T?>> GetMultipleByIds(IEnumerable<int> ids);
        public Task<T> Create(T entity);
        public Task<T> Update(T entity);
        public Task<bool> Delete(T entity);
    }
}
