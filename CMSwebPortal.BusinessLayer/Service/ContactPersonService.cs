using CMSwebPortal.BusinessLayer.IService;
using CMSwebPortal.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSwebPortal.BusinessLayer.Service
{
    public class ContactPersonService : IContactPersonService
    {
        private readonly IContactPersonService _contactPersonService;

        public ContactPersonService(IContactPersonService contactPersonService)
        {
            _contactPersonService = contactPersonService;
        }

        public async Task<ContactPerson> AddContactPerson(ContactPerson tbl)
        {
            return await _contactPersonService.AddContactPerson(tbl);
        }

        public async Task<ContactPerson> DeleteContactPerson(int id)
        {
            return await _contactPersonService.DeleteContactPerson(id);
        }

        public async Task<ContactPerson> GetContactPersonById(int id)
        {
            return await _contactPersonService.GetContactPersonById(id);
        }

        public async  Task<IEnumerable<ContactPerson>> GetContactPersons()
        {
            return await _contactPersonService.GetContactPersons();
        }

        public async Task<IEnumerable<ContactPerson>> SearchContactPerson(string name)
        {
            return await _contactPersonService.SearchContactPerson(name);
        }

        public async Task<ContactPerson> UpdateContactPerson(ContactPerson tbl)
        {
            return await _contactPersonService.UpdateContactPerson(tbl);
        }
    }
}
