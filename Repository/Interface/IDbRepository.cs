using CRUD_HomeWork.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_HomeWork.Repository.Interface
{
    public interface IDbRepository
    {
        public NorthwindContext dbcontext { get; }

        public void Create<T>(T entity) where T : class;
        public void Delete<T>(T entity) where T : class;
        public void Update<T>(T entity) where T : class;
        public IQueryable<T> GetAll<T>() where T : class;

        public void Save();

        Task CreateAsync<T>(T entity) where T : class;
        Task UpdateAsync<T>(T entity) where T : class;
        Task DeleteAsync<T>(T entity) where T : class;
        Task<T> GetByIdAsync<T>(params object[] keyValues) where T : class;
    }
}
