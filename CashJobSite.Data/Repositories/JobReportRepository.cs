using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CashJobSite.Models;

namespace CashJobSite.Data.Repositories
{
    public class JobReportRepository : IRepository<JobReport>
    {
        private readonly ICashJobSiteDbContext _dbContext;

        public JobReportRepository(ICashJobSiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public JobReport GetById(int id)
        {
            return _dbContext.JobReports
                .SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<JobReport> List()
        {
            return _dbContext.JobReports
                .ToList();
        }

        public IEnumerable<JobReport> List(Expression<Func<JobReport, bool>> predicate)
        {
            return _dbContext.JobReports
                .Where(predicate)
                .ToList();
        }

        public void Save(JobReport entity)
        {
            _dbContext.JobReports.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(JobReport entity)
        {
            var itemToRemove = _dbContext.JobReports.SingleOrDefault(x => x.Id == entity.Id);
            _dbContext.JobReports.Remove(itemToRemove);
            _dbContext.SaveChanges();
        }
    }
}