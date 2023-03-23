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
    public class UpsertingRepository : IUpsertingRepository
    {
        private readonly ApplicationDbContext _db;

        public UpsertingRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Activity> AddUpdateActivityUpserting(Activity tbl,int id)
        {
           if(id== null ||id==0)
            {
                var obj = await _db.Activity1.AddAsync(tbl);
                _db.SaveChanges();
                return obj.Entity;
                
            }
            else
            {
                var result = await _db.Activity1.FirstOrDefaultAsync(a => a.Id == tbl.Id);
                if (result != null)
                {

                    result.Title = tbl.Title;
                    result.Description = tbl.Description;
                    result.ActivityType = tbl.ActivityType;
                    result.Date = tbl.Date;
                    result.Path = tbl.Path;
                    result.Link = tbl.Link;
                    result.isHome = tbl.isHome;
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

        public async Task<Activity> DeleteActivityUpserting(int id)
        {
            var result = await _db.Activity1.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (result != null)
            {
                // removes data
                _db.Activity1.Remove(result);
                await _db.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Activity>> GetActivityUpserting()
        {
            try
            {
                return await _db.Activity1.ToListAsync();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public async Task<Activity> GetActivityUpsertingById(int id)
        {
            return await _db.Activity1.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

    }
}
