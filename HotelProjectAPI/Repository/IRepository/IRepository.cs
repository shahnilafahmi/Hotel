using HotelProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelProject.Repository.IRepository
{
      public interface IRepository<T> where T : class
        {
            Task<T> GetByIdAsync(int id);
            Task<IEnumerable<T>> GetAllAsync();
            Task AddAsync(T entity);
            void Update(T entity);
            void Delete(T entity);
        IQueryable<T> GetAllWithIncludesAsync(
           params Expression<Func<T, object>>[] includes);
        IEnumerable<T> GetByDate(DateTime? DateTime);
        void  RemoveRange(IEnumerable<T> entities);
        Task<IQueryable<T>> GetAsQueryAble();
    }

   
}
