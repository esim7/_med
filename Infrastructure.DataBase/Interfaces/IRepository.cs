using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Model;

namespace Infrastructure.DataBase.Interfaces
{
    public interface IRepository<T> where T : class
    {
        ValueTask<T> GetAsync(int? id);
        Task<List<T>> GetAllAsync();
        Task CreateAsync (T entity);
        T Edit(T entity);
        void Remove(T entity);
        bool Exist(int id);
    }
}