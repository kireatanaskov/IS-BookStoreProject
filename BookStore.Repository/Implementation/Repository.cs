using BookStore.Domain.Models;
using BookStore.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext dbContext;
        private DbSet<T> entities;

        public Repository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entities = dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return this.entities.AsEnumerable();
        }

        public T Get(Guid? id)
        {
            return entities.First(e => e.Id == id);
        }

        public T Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this.entities.Remove(entity);
            this.dbContext.SaveChanges();
            return entity;
        }

        public T Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this.entities.Add(entity);
            this.dbContext.SaveChanges();
            return entity;
        }

        public List<T> InsertMany(List<T> entities1)
        {
            if (entities1 == null)
            {
                throw new ArgumentNullException("entities");   
            }
            this.entities.AddRange(entities1);
            this.dbContext.SaveChanges();
            return entities1;
        }

        public T Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this.entities.Update(entity);
            this.dbContext.SaveChanges();
            return entity;
        }
    }
}
