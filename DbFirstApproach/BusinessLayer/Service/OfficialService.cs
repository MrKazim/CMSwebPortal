using DbFirstApproach.BusinessLayer.IService;
using DbFirstApproach.DbModels;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirstApproach.BusinessLayer.Service
{
    public class OfficialService : IOfficialService
    {
        private readonly FileCMSwebportalContext _db;

        public OfficialService(FileCMSwebportalContext db)
        {
            _db = db;
        }

        public async Task<Official> AddOfficial(Official tbl)
        {
            var obj = await _db.Officials.AddAsync(tbl);
            _db.SaveChanges();
            return obj.Entity;
        }

        public async Task<Official> DeleteOfficial(int id)
        {
            var result = await _db.Officials.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (result != null)
            {
                // removes data
                _db.Officials.Remove(result);
                await _db.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Official> GetOfficialById(int id)
        {
            return await _db.Officials.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Official>> GetOfficials()
        {
            try
            {
                return await _db.Officials.ToListAsync();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Official>> SearchOfficial(string name)
        {
            IQueryable<Official> query = _db.Officials;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.Name.Contains(name));
            }
            return await query.ToListAsync();
        }

        public async Task<Official> UpdateOfficial(Official tbl)
        {
            var result = await _db.Officials.FirstOrDefaultAsync(a => a.Id == tbl.Id);
            if (result != null)
            {
                result.Name = tbl.Name;
                result.Position = tbl.Position;
                result.Message = tbl.Message;
                result.Path = tbl.Path;
                result.Contact = tbl.Contact;
                result.IsHome = tbl.IsHome;
                result.From = tbl.From;
                result.To = tbl.To;
                result.Type = tbl.Type;
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
