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
    public class WorkService:IWorkService
    {
        private readonly IWorkRepository _workRepository;

        public WorkService(IWorkRepository workRepository)
        {
            _workRepository = workRepository;
        }

        public async Task<Work> AddWork(Work tbl)
        {
            return await _workRepository.AddWork(tbl);
        }

        public async Task<Work> DeleteWork(int id)
        {
            return await _workRepository.DeleteWork(id);
        }

        public async Task<IEnumerable<Work>> GetWork()
        {
            return await _workRepository.GetWork();
        }

        public async Task<Work> GetWorkById(int id)
        {
            return await _workRepository.GetWorkById(id);
        }

        public async Task<IEnumerable<Work>> SearchWork(string name)
        {
            return await _workRepository.SearchWork(name);
        }

        public async Task<Work> UpdateWork(Work tbl)
        {
            return await _workRepository.UpdateWork(tbl);
        }
    }
}
