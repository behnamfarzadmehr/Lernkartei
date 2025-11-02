using Lernkartei.Domain.Abstraction;
using Microsoft.EntityFrameworkCore;
using Swish.InfraStructure.context;
using System.Linq.Expressions;

namespace Lernkartei.InfraStructure.Concrete.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly LernkarteiContext _Context;
        private readonly DbSet<TEntity> _entities;
        public Repository(LernkarteiContext context)
        {
            _Context = context;
            _entities = context.Set<TEntity>();
        }
        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return _Context.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }
        public TEntity Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Add)} entity must not be null");
            }

            try
            {
                _Context.Add(entity);
                _Context.SaveChanges();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }
        public TEntity Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Update)} entity must not be null");
            }

            try
            {
                _Context.Update(entity);
                _Context.SaveChanges();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }
        public bool Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Delete)} entity must not be null");
            }

            try
            {
                _Context.Remove(entity);
                _Context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be deleted: {ex.Message}");
            }
        }
        public TEntity GetById(dynamic id)
        {
            try
            {
                return _Context.Set<TEntity>().Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }
        public IList<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate).ToList();
        }
        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Any(predicate);
        }
    }
}
