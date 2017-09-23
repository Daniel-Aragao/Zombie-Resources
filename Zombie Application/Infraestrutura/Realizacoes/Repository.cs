using Infraestrutura.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Realizacoes
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;

        private DbSet<T> dbSet;

        public Repository(DbContext Context)
        {
            this.Context = Context;
            dbSet = this.Context.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            T entity = this.GetSingle(id);
            this.Delete(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return this.dbSet.ToList();
        }

        public IEnumerable<T> GetAll(Func<T, bool> predicate)
        {
            return this.dbSet.Where(predicate).ToList();
        }

        public T GetSingle(int? id)
        {
            return dbSet.Find(id);
        }
    }
}
