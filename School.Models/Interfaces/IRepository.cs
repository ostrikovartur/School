using SchoolsTest.Models;
using System.Linq.Expressions;

namespace SchoolsTest.Models.Interfaces;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task Add(TEntity entity);
    Task Delete(TEntity entity);
    Task<IEnumerable<TEntity>> GetAll();
    Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate);
    Task Update(TEntity entity);

    Task<TEntity> Get(int id);
}
