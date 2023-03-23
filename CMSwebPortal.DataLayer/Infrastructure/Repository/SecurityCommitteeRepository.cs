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
    public class SecurityCommitteeRepository:ISecurityCommitteeRepository
    {
        private readonly ApplicationDbContext _db;
        public SecurityCommitteeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<SecurityCommittee> AddSecurityCommittee(SecurityCommittee tbl)
        {
            var obj = await _db.SecurityCommittee.AddAsync(tbl);
            _db.SaveChanges();
            return obj.Entity;
        }

        public async Task<SecurityCommittee> DeleteSecurityCommittee(int id)
        {
            var result = await _db.SecurityCommittee.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (result != null)
            {
                // removes data
                _db.SecurityCommittee.Remove(result);
                await _db.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<SecurityCommittee>> GetSecurityCommittee()
        {
            try
            {
                return await _db.SecurityCommittee.ToListAsync();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public async Task<SecurityCommittee> GetSecurityCommitteeById(int id)
        {
            return await _db.SecurityCommittee.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<SecurityCommittee>> SearchSecurityCommmittee(string name)
        {
            IQueryable<SecurityCommittee> query = _db.SecurityCommittee;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.Title.Contains(name));
            }
            return await query.ToListAsync();
        }

        public async Task<SecurityCommittee> UpdateSecurityCommittee(SecurityCommittee tbl)
        {
            var result = await _db.SecurityCommittee.FirstOrDefaultAsync(a => a.Id == tbl.Id);
            if (result != null)
            {
                result.Title = tbl.Title;
                result.Position = tbl.Position;
                result.CreatedBy = tbl.CreatedBy;
                result.ModifiedBy = tbl.ModifiedBy;
                result.CreatedDate = tbl.CreatedDate;
                result.ModifiedDate = tbl.ModifiedDate;
                result.IsActive = tbl.IsActive;
                await _db.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
