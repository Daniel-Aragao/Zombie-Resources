using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Interfaces
{
    public interface IRepository <T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Func<T, bool> predicate);
        T GetSingle(int? id);
        void Add(T entity);
        void Delete(T entity);
        void Delete(int id);
    }
}
