using CMSwebPortal.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSwebPortal.DataLayer.Infrastructure.IRepository
{
    public interface IUpsertingRepository
    {
        Task<IEnumerable<Activity>> GetActivityUpserting();
        Task<Activity> GetActivityUpsertingById(int id);
        
        //Manage in  One method Both Update and Inserting
        Task<Activity> AddUpdateActivityUpserting(Activity tbl,int id);
        Task<Activity> DeleteActivityUpserting(int id);
    }
}
