using System;
using System.Collections.Generic;
using System.Text;

namespace LightCut.Services
{
    public interface IService<T> where T : class
    {
        List<T> Get();

        T Get(string id);

        T Create(T entity);


    }
}
