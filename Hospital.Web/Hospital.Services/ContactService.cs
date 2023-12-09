using Hospital.Models;
using Hospital.ModelViews;
using Hospital.Repository.Interfaces;
using Hospital.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public class ContactService : IContactService
    {
        public readonly IUnitOfWork UnitOfWork;

        public ContactService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public void DeleteContact(int id)
        {
            var model = UnitOfWork.GenericRepository<Contact>().GetById(id);
            UnitOfWork.GenericRepository<Contact>().Delete(model);
            UnitOfWork.save();
        }

        public PagedResult<ContactViewModel> GetAll(int pagenumber, int pagesize)
        {
            var vm = new ContactViewModel();
            int totalCount;
            List<ContactViewModel> viewModels = new List<ContactViewModel>();
            try
            {
                int ExcludeRecords = (pagenumber * pagesize) - pagesize;
                var modelList = UnitOfWork.GenericRepository<Contact>().GetAll(includeProperties:"Hospital").Skip(ExcludeRecords).Take(pagesize).ToList();
                totalCount = UnitOfWork.GenericRepository<Contact>().GetAll().ToList().Count;
                viewModels = ConvertModelToViewModelList(modelList);
            }
            catch (Exception ex)
            {
                throw;
            }
            var result = new PagedResult<ContactViewModel>()
            {
                Data = viewModels,
                TotalItems = totalCount,
                PageNumber = pagenumber,
                PageSize = pagesize
            };
            return result;
        }
        public ContactViewModel GetContactById(int id)
        {
            var model = UnitOfWork.GenericRepository<Contact>().GetById(id);
            var vm = new ContactViewModel(model);
            return vm;
        }

        public void InsertContact(ContactViewModel Contact)
        {
            var model = new ContactViewModel().ConvertViewModel(Contact);
            UnitOfWork.GenericRepository<Contact>().Add(model);
            UnitOfWork.save();
        }

        public void UpdateContact(ContactViewModel Contact)
        {
            var model = new ContactViewModel().ConvertViewModel(Contact);
            var modelById = UnitOfWork.GenericRepository<Contact>().GetById(model.Id);
            modelById.Phone = model.Phone;
            modelById.Email = model.Email;
            modelById.HospitalId = model.HospitalId;
            UnitOfWork.GenericRepository<Contact>().Update(model);
            UnitOfWork.save();
        }
        public List<ContactViewModel> ConvertModelToViewModelList(List<Contact> contacts)
        {
            return contacts.Select(x => new ContactViewModel(x)).ToList();
        }
    }
}

