using CMSwebPortal.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSwebPortal.BusinessLayer.IService
{
    public interface IContactPersonService
    {
        //Get All ContactPerson Data
        Task<IEnumerable<ContactPerson>> GetContactPersons();

        //Get ContactPerson Data with Specific Id
        Task<ContactPerson> GetContactPersonById(int id);

        //Add New ContactPerson Data
        Task<ContactPerson> AddContactPerson(ContactPerson tbl);

        //Update ContactPerson Data
        Task<ContactPerson> UpdateContactPerson(ContactPerson tbl);

        //Delete ContactPerson Data

        Task<ContactPerson> DeleteContactPerson(int id);

        //Search ContactPerson Data With Name
        Task<IEnumerable<ContactPerson>> SearchContactPerson(string name);
    }
}
