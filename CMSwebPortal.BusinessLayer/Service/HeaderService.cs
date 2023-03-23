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
    public class HeaderService : IHeaderService
    {
        private readonly IHeaderRepository _headerRepository;

        public HeaderService(IHeaderRepository headerRepository)
        {
            _headerRepository = headerRepository;
        }

        public async Task<Header> AddHeader(Header tbl)
        {
            return await _headerRepository.AddHeader(tbl);
        }

        public async Task<Header> DeleteHeader(int id)
        {
            return await _headerRepository.DeleteHeader(id);
        }

        public async Task<Header> GetHeaderById(int id)
        {
            return await _headerRepository.GetHeaderById(id);
        }

        public async Task<IEnumerable<Header>> GetHeaders()
        {
            return await _headerRepository.GetHeaders();
        }

        public async Task<IEnumerable<Header>> SearchHeader(string name)
        {
            return await _headerRepository.SearchHeader(name);
        }

        public async Task<Header> UpdateHeader(Header tbl)
        {
            return await _headerRepository.UpdateHeader(tbl);
        }
    }
}
