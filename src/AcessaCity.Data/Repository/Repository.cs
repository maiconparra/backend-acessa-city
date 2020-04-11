using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Models;
using AcessaCity.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AcessaCity.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly AppDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(AppDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();            
        }

        public virtual async Task Add(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }


        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task Remove(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }


        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }


        public virtual async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }
    }
}