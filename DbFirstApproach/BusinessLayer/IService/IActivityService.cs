using DbFirstApproach.DbModels;

namespace DbFirstApproach.BusinessLayer.IService
{
    public interface IActivityService
    {
        //Get All Activity Data
        Task<IEnumerable<Activity1>> GetActivitys();

        //Get Activity Data with Specific Id
        Task<Activity1> GetActivityById(int id);

        //Add New Activity Data
        Task<Activity1> AddActivity(Activity1 tbl);

        //Update Activity Data
        Task<Activity1> UpdateActivity(Activity1 tbl);

        //Delete Activity Data

        Task<Activity1> DeleteActivity(int id);

        //Search Activity Data With Name
        Task<IEnumerable<Activity1>> SearchActivity(string name);
    }
}
