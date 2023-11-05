using Microsoft.EntityFrameworkCore;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;
using System.Linq.Expressions;

namespace SchoolsTest.Data;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly AppDbContext DbContext;

    public Repository(AppDbContext dbContext)
    {
        DbContext = dbContext;
    }
    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await DbContext.Set<TEntity>().ToArrayAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbContext.Set<TEntity>()
            .Where(predicate)
            .ToArrayAsync();
    }

    public async Task<TEntity> Get(int id)
    {
        return await DbContext.Set<TEntity>().FindAsync(id);
    }

    public async Task Add(TEntity entity)
    {
        DbContext.Set<TEntity>().Add(entity);
        await DbContext.SaveChangesAsync();
    }
    public async Task Update(TEntity entity)
    {
        DbContext.Update(entity);
        await DbContext.SaveChangesAsync();
    }
    public async Task Delete(TEntity entity)
    {
        DbContext.Remove(entity);
        await DbContext.SaveChangesAsync();
    }
}
