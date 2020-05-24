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

        void Update(T entity);

        void Remove(string id);

        void Remove(T entity);
    }
}
