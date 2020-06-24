using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.DataBase.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(int? id);
        Task<List<T>> GetAllAsync();
        ValueTask<EntityEntry<T>> CreateAsync(T entity);
        ValueTask<T> EditAsync(T entity);
        void Remove(T entity);
        bool Exist(int id);
    }
}