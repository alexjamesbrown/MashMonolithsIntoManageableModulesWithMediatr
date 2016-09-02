using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CashJobSite.Models;

namespace CashJobSite.Data.Repositories
{
    public class JobRepository : IRepository<Job>
    {
        private readonly ICashJobSiteDbContext _dbContext;

        public JobRepository(ICashJobSiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Job GetById(int id)
        {
            return _dbContext.Jobs
                .SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Job> List()
        {
            return _dbContext.Jobs
                .ToList();
        }

        public IEnumerable<Job> List(Expression<Func<Job, bool>> predicate)
        {
            return _dbContext.Jobs
                .Where(predicate)
                .ToList();
        }

        public void Save(Job entity)
        {
            _dbContext.Jobs.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Job entity)
        {
            var itemToRemove = _dbContext.Jobs.SingleOrDefault(x => x.Id == entity.Id);
            _dbContext.Jobs.Remove(itemToRemove);
            _dbContext.SaveChanges();
        }
    }
}