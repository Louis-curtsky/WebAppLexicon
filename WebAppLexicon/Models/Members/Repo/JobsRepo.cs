using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Members.Data;
using WebAppLexicon.Models.Members.ViewModel;

namespace WebAppLexicon.Models.Members.Repo
{
    public class JobsRepo : IJobsRepo
    {
        private readonly MemberDbContext _memberDbContext;

        public JobsRepo(MemberDbContext memberDbContext)
        {
            _memberDbContext = memberDbContext;
        }

        public Jobs Create(CreateJobsViewModel jobs, int id)
        {
            Jobs storeJobs = new Jobs()
            {
                JobId = id,
                JobDesc = jobs.JobDesc,
                StartDate = jobs.StartDate,
                EndDate = jobs.EndDate,
                JobComments = jobs.JobComments
            };
            _memberDbContext.Jobs.Add(storeJobs);
            _memberDbContext.SaveChanges();
            return storeJobs;
        }

        public bool Delete(Jobs jobs)
        {
            _memberDbContext.Jobs.Remove(jobs);
            int returnValue = _memberDbContext.SaveChanges();
            return returnValue == 1 ? true : false;
        }

        public Jobs FindById(int id)
        {
            Jobs jobFound = _memberDbContext.Jobs.Find(id);
            return jobFound;
        }

        public List<Jobs> GetAll()
        {
            return (_memberDbContext.Jobs.Include(jobs=>jobs.Skills).ToList());
        }

        public Jobs Update(Jobs jobs)
        {
            _memberDbContext.Jobs.Update(jobs);
            if (_memberDbContext.SaveChanges() > 0)
            {
                return jobs;
            }
            else
                return null;
        }
    }
}
