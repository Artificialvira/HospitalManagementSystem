using Hospital.ModelViews;
using Hospital.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public interface IContactService
    {
        PagedResult<ContactViewModel> GetAll(int pagenumber, int pagesize);
        ContactViewModel GetContactById(int id);
        void UpdateContact(ContactViewModel contact);
        void DeleteContact(int id);
        void InsertContact(ContactViewModel contact);   
    }
}
