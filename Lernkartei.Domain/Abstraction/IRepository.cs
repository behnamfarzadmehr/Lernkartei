using System.Linq.Expressions;

namespace Lernkartei.Domain.Abstraction
{
    public interface IRepository<TEntity> where TEntity : class,new()
    {
        public IQueryable<TEntity> GetAll();
        public TEntity GetById(dynamic id);
        public TEntity Add(TEntity entity);
        public TEntity Update(TEntity entity);
        public bool Delete(TEntity entity);
        public IList<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        public bool Any(Expression<Func<TEntity, bool>> predicate);
    }
}
