using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HotelProject.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public IQueryable<T> GetAllWithIncludesAsync(
            params Expression<Func<T, object>>[] includes)
        {
            
            IQueryable<T> query = _dbSet.AsQueryable();
 
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return  query;
        }
     

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        //public IEnumerable<T> GetByDate(DateTime? DateTime)
        //{
        //    if (DateTime == null)
        //    {
        //        throw new ArgumentNullException(nameof(DateTime), "DateTime cannot be null");
        //    }

        //    return _dbSet.Where(entity => EF.Property<DateTime>(entity, "Date") == DateTime.Value.Date).ToList();
        //}

        public IEnumerable<T> GetByDate(DateTime? dateTime)
        {
            if (dateTime == null)
            {
                throw new ArgumentNullException(nameof(dateTime), "DateTime cannot be null");
            }

            // Dynamically find the first DateTime or nullable DateTime property
            var dateProperty = typeof(T).GetProperties()
                .FirstOrDefault(p => p.PropertyType == typeof(DateTime) ||
                                     p.PropertyType == typeof(DateTime?));

            if (dateProperty == null)
            {
                throw new InvalidOperationException($"No DateTime property found in {typeof(T).Name}");
            }

            // Build a dynamic query to filter based on the identified property
            var parameter = Expression.Parameter(typeof(T), "entity");
            var propertyAccess = Expression.Property(parameter, dateProperty.Name);
            var value = Expression.Constant(dateTime.Value.Date);

            // Handle nullable DateTime properties
            var datePropertyAccess = dateProperty.PropertyType == typeof(DateTime?)
                ? Expression.Property(propertyAccess, "Value") // Access the underlying value
                : propertyAccess;

            var dateOnlyAccess = Expression.Property(datePropertyAccess, nameof(DateTime.Date));
            var equalExpression = Expression.Equal(dateOnlyAccess, value);
            var lambda = Expression.Lambda<Func<T, bool>>(equalExpression, parameter);

            // Apply the filter and return the results
            return _dbSet.Where(lambda).ToList();
        }
        //




        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public  Task<IQueryable<T>> GetAsQueryAble()
        {
           return Task.FromResult(_dbSet.AsQueryable()) ;
        }
    }

}
