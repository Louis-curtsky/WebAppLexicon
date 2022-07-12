using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Members.Repo;
using WebAppLexicon.Models.Members.ViewModel;

namespace WebAppLexicon.Models.Members.Services
{
    public class JobServices : IJobSevices
    {
        private readonly IJobsRepo _jobsRepo;

        public JobServices(IJobsRepo jobsRepo)
        {
            _jobsRepo = jobsRepo;
        }
        public Jobs Create(CreateJobsViewModel jobs)
        {
            List<Jobs> getAllJobs = new List<Jobs>(); 
            getAllJobs = GetAll();
            int assignId = 0;
            if (getAllJobs.Count == 0)
            {
                assignId = 1;
            }
            else
            {
                assignId = getAllJobs[getAllJobs.Count - 1].JobId;
            }
            return (_jobsRepo.Create(jobs, assignId));
        }

        public Jobs Edit(int id, Jobs jobs)
        {
            throw new NotImplementedException();
        }

        public Jobs FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Jobs> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
