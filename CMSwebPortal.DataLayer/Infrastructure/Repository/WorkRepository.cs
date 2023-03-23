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
    public class WorkRepository:IWorkRepository
    {
        private readonly ApplicationDbContext _db;
        public WorkRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Work> AddWork(Work tbl)
        {

            var obj = await _db.Work.AddAsync(tbl);
            _db.SaveChanges();
            return obj.Entity;
        }

        public async Task<Work> DeleteWork(int id)
        {
            var result = await _db.Work.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (result != null)
            {
                // removes data
                _db.Work.Remove(result);
                await _db.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<IEnumerable<Work>> GetWork()
        {
            try
            {
                return await _db.Work.ToListAsync();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public async Task<Work> GetWorkById(int id)
        {
            return await _db.Work.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Work>> SearchWork(string name)
        {
            IQueryable<Work> query = _db.Work;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.Title.Contains(name));
            }
            return await query.ToListAsync();
        }

        public async Task<Work> UpdateWork(Work tbl)
        {
            var result = await _db.Work.FirstOrDefaultAsync(a => a.Id == tbl.Id);
            if (result != null)
            {
                result.Title = tbl.Title;
                result.Description = tbl.Description;
                result.Path = tbl.Path;
                result.Type = tbl.Path;
                result.Date = tbl.Date;
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
