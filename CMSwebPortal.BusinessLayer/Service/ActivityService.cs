using CMSwebPortal.BusinessLayer.IService;
using CMSwebPortal.DataLayer.Infrastructure.IRepository;
using CMSwebPortal.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSwebPortal.BusinessLayer.Service
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;

        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task<Activity> AddActivity(Activity tbl)
        {
            return await _activityRepository.AddActivity(tbl);
        }

        public async Task<Activity> DeleteActivity(int id)
        {
            return await _activityRepository.DeleteActivity(id);
        }

        public async Task<Activity> GetActivityById(int id)
        {
            return await _activityRepository.GetActivityById(id);
        }

        public async Task<IEnumerable<Activity>> GetActivitys()
        {
            return await _activityRepository.GetActivitys();
        }

        public async Task<IEnumerable<Activity>> SearchActivity(string name)
        {
            return await _activityRepository.SearchActivity(name);
        }

        public async Task<Activity> UpdateActivity(Activity tbl)
        {
            return await _activityRepository.UpdateActivity(tbl);
        }
    }
}
