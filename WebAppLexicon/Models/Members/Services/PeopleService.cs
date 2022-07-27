using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Members.Repo;
using WebAppLexicon.Models.Members.ViewModel;

namespace WebAppLexicon.Models.Members.Services
{
    public class PeopleService : IPeopleService
    {

        IPeopleRepo _peopleRepo;

        public PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;

        }

        public List<Members> All()
        {
            return _peopleRepo.All();
        }

        public void Edit(int id, MemberViewModel personViewModel)
        {
            Members member = _peopleRepo.FindByID(id);
            if (member != null)
            {
                member.FirstName = personViewModel.FirstName;
                member.LastName = personViewModel.LastName;
                member.Phone = personViewModel.Phone;
                member.CntyId = personViewModel.CntyId;
                member.StateId = personViewModel.StateId;
                member.CtyId = personViewModel.CtyId;

                _peopleRepo.Update(member);
                //_peopleRepo.UpdateLang(person.Id, langId);
            }
        }

        public Members FindById(int id)
        {
            Members returnFound = _peopleRepo.FindByID(id);
            return returnFound;

        }

        public List<Members> FindLast()
        {
            return _peopleRepo.FindLast();
        }
        public bool Remove(int id)
        {
            Members member = _peopleRepo.Read(id);
            if (member == null)
                return false;
            else
                return _peopleRepo.Delete(member);
        }

        //public Members Add(CreateMemberViewModel personViewModel, List<MemberLanguage> personLang)
        public Members Add(CreateMemberViewModel personViewModel)
        {
            Members member = new Members();

            member.FirstName = personViewModel.FirstName;
            member.LastName = personViewModel.LastName;
            member.Phone = personViewModel.Phone;
            member.CntyId = personViewModel.CntyId;
            member.StateId = personViewModel.StateId;
            member.CtyId = personViewModel.CtyId;
            member.Nationality = personViewModel.Nationality;
            member.Age = personViewModel.Age;
            member.Email = personViewModel.Email;
            member.Gender = personViewModel.Gender;
            member.GovIdType = personViewModel.GovIdType;
            member.GovId = personViewModel.GovId;
            member.LangId = personViewModel.LangId;
            member.LangRead1 = personViewModel.LangRead1;
            member.LangWrite1 = personViewModel.LangWrite1;
            member.MemberType = personViewModel.MemberType;
            member.MemberApproval = "Pending";
            member.MemberDate = personViewModel.MemberDate;

            return _peopleRepo.Create(member);

        }

        public List<Members> Search(string firstName, string lastName, int countryId, int cityId)
        {
            List<Members> member = _peopleRepo.Search(firstName, lastName, countryId, cityId);
            return member;
        }

        public string UploadedFile(CreateMemberViewModel model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                //               string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                string uploadsFolder = Path.Combine("wwwroot/", "images");
                uniqueFileName = "_" + model.ProfileImage.FileName;
//                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                model.ProfileImage.CopyTo(fileStream);
            }
            return uniqueFileName;
        }
        /*        public List<PersonLanguage> GetLanguage(int id)
                {
                    return _peopleRepo.GetLanguage(id);
                }*/
    }
}

