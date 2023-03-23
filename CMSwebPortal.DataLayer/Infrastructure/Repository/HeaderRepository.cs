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
    public class HeaderRepository : IHeaderRepository
    {
        private readonly ApplicationDbContext _db;

        public HeaderRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Header> AddHeader(Header tbl)
        {
            var obj = await _db.Header.AddAsync(tbl);
            _db.SaveChanges();
            return obj.Entity;
        }

        public async Task<Header> DeleteHeader(int id)
        {
            var result = await _db.Header.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (result != null)
            {
                // removes data
                _db.Header.Remove(result);
                await _db.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Header> GetHeaderById(int id)
        {
            return await _db.Header.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Header>> GetHeaders()
        {
            try
            {
                return await _db.Header.ToListAsync();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Header>> SearchHeader(string name)
        {
            IQueryable<Header> query = _db.Header;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.Title.Contains(name));
            }
            return await query.ToListAsync();
        }

        public async Task<Header> UpdateHeader(Header tbl)
        {
            var result = await _db.Header.FirstOrDefaultAsync(a => a.Id == tbl.Id);
            if (result != null)
            {
                result.Label = tbl.Label;
                result.Title = tbl.Title;
                result.Description = tbl.Description;
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
