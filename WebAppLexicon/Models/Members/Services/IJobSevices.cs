using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Members.ViewModel;

namespace WebAppLexicon.Models.Members.Services
{
    public interface IJobSevices
    {
        Jobs Create(CreateJobsViewModel jobs);
        List<Jobs> GetAll();
        Jobs FindById(int id);
        Jobs Edit(int id, Jobs jobs);
        bool Remove(int id); 
    }
}
