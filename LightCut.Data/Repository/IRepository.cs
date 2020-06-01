using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LightCut.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        T Get(string id);

        IEnumerable<T> GetAll();

        void Add(T entity);

        bool Update(T entity);

        bool Remove(string id);

        bool Remove(T entity);
    }
}
