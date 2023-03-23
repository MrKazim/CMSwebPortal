using DbFirstApproach.BusinessLayer.IService;
using DbFirstApproach.DbModels;
using Microsoft.EntityFrameworkCore;

namespace DbFirstApproach.BusinessLayer.Service
{
    public class ActivityService : IActivityService
    {
        private readonly FileCMSwebportalContext _db;

        public ActivityService(FileCMSwebportalContext db)
        {
            _db = db;
        }
        public async Task<Activity1> AddActivity(Activity1 tbl)
        {
            var obj = await _db.Activity1s.AddAsync(tbl);
            _db.SaveChanges();
            return obj.Entity;
        }

        public async Task<Activity1> DeleteActivity(int id)
        {
            var result = await _db.Activity1s.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (result != null)
            {
                // removes data
                _db.Activity1s.Remove(result);
                await _db.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Activity1> GetActivityById(int id)
        {
            return await _db.Activity1s.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Activity1>> GetActivitys()
        {
            try
            {
                return await _db.Activity1s.ToListAsync();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Activity1>> SearchActivity(string name)
        {
            IQueryable<Activity1> query = _db.Activity1s;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.Title.Contains(name));
            }
            return await query.ToListAsync();
        }

        public async Task<Activity1> UpdateActivity(Activity1 tbl)
        {
            var result = await _db.Activity1s.FirstOrDefaultAsync(a => a.Id == tbl.Id);
            if (result != null)
            {

                result.Title = tbl.Title;
                result.Description = tbl.Description;
                result.ActivityType = tbl.ActivityType;
                result.Date = tbl.Date;
                result.Path = tbl.Path;
                result.Link = tbl.Link;
                result.IsHome = tbl.IsHome;
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
