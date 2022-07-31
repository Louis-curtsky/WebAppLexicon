using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Members.ViewModel;

namespace WebAppLexicon.Models.Members.Services
{
    public interface IPeopleService
    {
        List<Members> All();
        Members Add(CreateMemberViewModel memberViewModel);
        Members FindById(int id);
        List<Members> FindLast();
        bool Edit(Members member);
        bool Remove(int id);
        List<Members> Search(string firstName, string lastName, int countryId, int cityId);
        string UploadedFile(CreateMemberViewModel model);
        FileStream DownLoadFile(string fileName);
    }
}
