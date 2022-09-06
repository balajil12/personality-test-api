using Microsoft.EntityFrameworkCore;
using personality_test_api.Db.Connections;
using System.Linq.Expressions;

namespace personality_test_api.Db.Repositories
{
    public interface IRepository<T>
    {
        T GetById(int id);
        IQueryable<T> GetAll();
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);
        bool Any(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteMultiple(List<T> entities);
        void Commit();
    }
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDb _db;
        public Repository(AppDb db)
        {
            _db = db;
        }

        public IQueryable<T> GetAll() => _db.Set<T>().AsNoTracking();
        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression) =>
            _db.Set<T>().Where(expression).AsNoTracking();
        public bool Any(Expression<Func<T, bool>> expression) =>
            _db.Set<T>().Where(expression).Any();
        public T GetById(int id) => _db.Set<T>().Find(id);
        public void Create(T entity) => _db.Set<T>().Add(entity);
        public void Update(T entity) => _db.Set<T>().Update(entity);
        public void Delete(T entity) => _db.Set<T>().Remove(entity);
        public void DeleteMultiple(List<T> entities) => _db.Set<T>().RemoveRange(entities);
        public void Commit() => _db.SaveChanges();
    }
}
