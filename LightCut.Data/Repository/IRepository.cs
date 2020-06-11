using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LightCut.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(string id);

        Task<IEnumerable<T>> GetAll();

        void Add(T entity);

        Task<bool> Update(T entity);

        Task<bool> Remove(string id);

        Task<bool> Remove(T entity);
    }
}
