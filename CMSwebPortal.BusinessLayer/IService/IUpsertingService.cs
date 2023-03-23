using CMSwebPortal.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSwebPortal.BusinessLayer.IService
{
    public interface IUpsertingService
    {
        Task<IEnumerable<Activity>> GetActivityUpserting();
        Task<Activity> GetActivityUpsertingById(int id);
        //Task<Activity> AddActivityUpserting(Activity tbl);
        //Task<Activity> UpdateActivityUpserting(Activity tbl);
        //Manage in  One method Both Update and Inserting
        Task<Activity> AddUpdateActivityUpserting(Activity tbl,int id);
        Task<Activity> DeleteActivityUpserting(int id);
    }
}
