using Microsoft.EntityFrameworkCore;
using OtoServisSatis.Data.Abstract;
using OtoServisSatis.Entity;
using System.Linq.Expressions;

namespace OtoServisSatis.Data.Concrete
{
    public class Repository<T> : IRepository<T> where T : class, IEntity, new()
    {
        internal DatabaseContext _context;

        public Repository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        internal DbSet<T> _dbSet;

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public T Find(int id)
        {
            return _dbSet.Find(id); 
        }

        public async Task<T> FindAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);
        }

        public List<T> GetAll()
        {
           return _dbSet.ToList();    
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).ToList();
        }

        public async Task<List<T>> GetAllAsync()
        {
            //if (typeof(T) == typeof(Arac))
            //{
            //    return await _dbSet.Include("Marka")
            //                       .Include("KasaTipis")
            //                       .ToListAsync() as List<T>;
            //}
            return await _dbSet.ToListAsync();
        }
        //public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        //{
        //    IQueryable<T> query = _dbSet;

        //    if (typeof(T) == typeof(Arac))
        //    {
        //        query = query.Include("Marka")
        //                     .Include("KasaTipis");
        //    }

        //    if (expression != null)
        //    {
        //        query = query.Where(expression);
        //    }

        //    return await query.ToListAsync();
        //}
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
