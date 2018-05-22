using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Pos.Repository.BaseRepository
{
    public interface IRepository<T> where T : class
    {
        T Get(string id);
        IEnumerable<T> GetAll();        
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }

}
