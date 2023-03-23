using CMSwebPortal.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSwebPortal.BusinessLayer.IService
{
    public interface IActivityService
    {
        //Get All Activity Data
        Task<IEnumerable<Activity>> GetActivitys();

        //Get Activity Data with Specific Id
        Task<Activity> GetActivityById(int id);

        //Add New Activity Data
        Task<Activity> AddActivity(Activity  tbl);

        //Update Activity Data
        Task<Activity> UpdateActivity(Activity tbl);

        //Delete Activity Data

        Task<Activity> DeleteActivity(int id);

        //Search Activity Data With Name
        Task<IEnumerable<Activity>> SearchActivity(string name);
    }
}
