//using CRUD_HomeWork.Models.DBEntity;
//using CRUD_HomeWork.Repository.Interface;
//using Microsoft.EntityFrameworkCore;
//using System.Linq;

//namespace CRUD_HomeWork.Repository
//{
//    public class DbRepository : IDbRepository
//    {

//        private readonly NorthwindContext _dbcontext;

//        public DbRepository(NorthwindContext dbcontext)
//        {
//            _dbcontext = dbcontext;
//        }
//        public NorthwindContext dbcontext { get { return _dbcontext; } }

//        public void Create<T>(T entity) where T : class
//        {
//            _dbcontext.Entry<T>(entity).State = EntityState.Added;
//        }
//        public void Update<T>(T entity) where T : class
//        {
//            _dbcontext.Entry<T>(entity).State = EntityState.Modified;
//        }

//        public void Delete<T>(T entity) where T : class
//        {
//            _dbcontext.Entry<T>(entity).State = EntityState.Deleted;
//        }

//        public IQueryable<T> GetAll<T>() where T : class
//        {
//            return _dbcontext.Set<T>();
//        }

//        public void Save()
//        {
//            _dbcontext.SaveChanges();
//        }

//    }
//}
