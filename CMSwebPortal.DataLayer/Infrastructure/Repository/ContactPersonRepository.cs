using CMSwebPortal.DataLayer.Infrastructure.IRepository;
using CMSwebPortal.Models.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSwebPortal.DataLayer.Infrastructure.Repository
{
    public class ContactPersonRepository : IContactPersonRepository
    {
        private readonly ApplicationDbContext _db;

        public ContactPersonRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ContactPerson> AddContactPerson(ContactPerson tbl)
        {
            var obj = await _db.ContactPerson.AddAsync(tbl);
            _db.SaveChanges();
            return obj.Entity;
        }

        public async Task<ContactPerson> DeleteContactPerson(int id)
        {
            var result = await _db.ContactPerson.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (result != null)
            {
                // removes data
                _db.ContactPerson.Remove(result);
                await _db.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<ContactPerson> GetContactPersonById(int id)
        {
            return await _db.ContactPerson.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ContactPerson>> GetContactPersons()
        {
            try
            {
                return await _db.ContactPerson.ToListAsync();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ContactPerson>> SearchContactPerson(string name)
        {
            IQueryable<ContactPerson> query = _db.ContactPerson;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.Name.Contains(name));
            }
            return await query.ToListAsync();
        }

        public async Task<ContactPerson> UpdateContactPerson(ContactPerson tbl)
        {
            var result = await _db.ContactPerson.FirstOrDefaultAsync(a => a.Id == tbl.Id);
            if (result != null)
            {
                result.Name = tbl.Name;
                result.Position = tbl.Position;
                result.Phone = tbl.Phone;
                await _db.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
