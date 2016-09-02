using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CashJobSite.Models;

namespace CashJobSite.Data.Repositories
{
    public class JobApplicationRepository : IRepository<JobApplication>
    {
        private readonly ICashJobSiteDbContext _dbContext;

        public JobApplicationRepository(ICashJobSiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public JobApplication GetById(int id)
        {
            return _dbContext.JobApplications
                .SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<JobApplication> List()
        {
            return _dbContext.JobApplications
                .ToList();
        }

        public IEnumerable<JobApplication> List(Expression<Func<JobApplication, bool>> predicate)
        {
            return _dbContext.JobApplications
                .Where(predicate)
                .ToList();
        }

        public void Save(JobApplication entity)
        {
            _dbContext.JobApplications.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(JobApplication entity)
        {
            var itemToRemove = _dbContext.JobApplications.SingleOrDefault(x => x.Id == entity.Id);
            _dbContext.JobApplications.Remove(itemToRemove);
            _dbContext.SaveChanges();
        }
    }
}