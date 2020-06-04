using System;
using System.Linq;
using System.Linq.Expressions;

namespace StockManagement.Data.IRepositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll ();
        IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression);
        TEntity FindById(int id);
        TEntity Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        bool Exists(Expression<Func<TEntity, bool>> expression);
    }
}
