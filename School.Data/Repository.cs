﻿using Microsoft.EntityFrameworkCore;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;
using System.Linq.Expressions;

namespace SchoolsTest.Data;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    public readonly AppDbContext _dbContext;

    public Repository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IEnumerable<TEntity> GetAll()
    {
        return _dbContext.Set<TEntity>().ToArray();
    }

    public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbContext.Set<TEntity>()
            .Where(predicate)
            .ToArray();
    }

    public TEntity Get(int id)
    {
        return _dbContext.Set<TEntity>().Find(id);
    }

    public void Add(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
        _dbContext.SaveChanges();
    }
    public void Update(TEntity entity)
    {
        _dbContext.Update(entity);
        _dbContext.SaveChanges();
    }
    public void Delete(TEntity entity)
    {
        _dbContext.Remove(entity);
        _dbContext.SaveChanges();
    }
}