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
    public class UpsertingService : IUpsertingService
    {
        private readonly IUpsertingRepository _upsertingRepository;

        public UpsertingService(IUpsertingRepository upsertingRepository)
        {
            _upsertingRepository = upsertingRepository;
        }

        public async Task<Activity> AddUpdateActivityUpserting(Activity tbl, int id)
        {
                return await _upsertingRepository.AddUpdateActivityUpserting(tbl, id);
        }

        public async Task<Activity> DeleteActivityUpserting(int id)
        {
            return await _upsertingRepository.DeleteActivityUpserting(id);
        }

        public async Task<IEnumerable<Activity>> GetActivityUpserting()
        {
            return await _upsertingRepository.GetActivityUpserting();
        }

        public async Task<Activity> GetActivityUpsertingById(int id)
        {
            return await _upsertingRepository.GetActivityUpsertingById(id);
        }

       
    }
}
