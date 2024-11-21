using CRUD_HomeWork.Data;
using CRUD_HomeWork.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_HomeWork.Repository
{
    public class DbRepository : IDbRepository
    {

        private readonly NorthwindContext _dbcontext;

        public DbRepository(NorthwindContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public NorthwindContext dbcontext { get { return _dbcontext; } }

        public void Create<T>(T entity) where T : class
        {
            _dbcontext.Entry<T>(entity).State = EntityState.Added;
        }
        public void Update<T>(T entity) where T : class
        {
            _dbcontext.Entry<T>(entity).State = EntityState.Modified;
        }

        public void Delete<T>(T entity) where T : class
        {
            _dbcontext.Entry<T>(entity).State = EntityState.Deleted;
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            return _dbcontext.Set<T>();
        }

        public void Save()
        {
            _dbcontext.SaveChanges();
        }

        public async Task CreateAsync<T>(T entity) where T : class
        {
            await _dbcontext.Set<T>().AddAsync(entity);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            _dbcontext.Entry(entity).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            _dbcontext.Entry(entity).State = EntityState.Deleted;
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync<T>(params object[] keyValues) where T : class
        {
            return await _dbcontext.Set<T>().FindAsync(keyValues);
        }

    }
}
