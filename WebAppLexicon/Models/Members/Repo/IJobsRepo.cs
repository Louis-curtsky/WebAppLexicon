using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Members.ViewModel;

namespace WebAppLexicon.Models.Members.Repo
{
    public interface IJobsRepo
    {
        Jobs Create(CreateJobsViewModel createJobsViewModel, int id);
        List<Jobs> GetAll();
        Jobs FindById(int Id);
        Jobs Update(Jobs jobs);
        bool Delete(Jobs jobs);
    }
}
