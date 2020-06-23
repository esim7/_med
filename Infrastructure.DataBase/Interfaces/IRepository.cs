using System.Collections.Generic;

namespace Infrastructure.DataBase.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Get(int? id);
        IList<T> GetAll();
        T Create(T entity);
        T Edit(T entity);
        void Remove(T entity);
    }
}