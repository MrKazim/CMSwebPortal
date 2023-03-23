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
    public class SecurityCommitteeService:ISecurityCommitteeService
    {
        private readonly ISecurityCommitteeRepository _securityCommitteRepository;

        public SecurityCommitteeService(ISecurityCommitteeRepository securityCommitteRepository)
        {
            _securityCommitteRepository = securityCommitteRepository;
        }

        public async Task<SecurityCommittee> AddSecurityCommittee(SecurityCommittee tbl)
        {
            return await _securityCommitteRepository.AddSecurityCommittee(tbl);
        }

        public async Task<SecurityCommittee> DeleteSecurityCommittee(int id)
        {
            return await _securityCommitteRepository.DeleteSecurityCommittee(id);
        }

        public async Task<IEnumerable<SecurityCommittee>> GetSecurityCommittee()
        {
            return await _securityCommitteRepository.GetSecurityCommittee();
        }

        public async Task<SecurityCommittee> GetSecurityCommitteeById(int id)
        {
            return await _securityCommitteRepository.GetSecurityCommitteeById(id);
        }

        public async Task<IEnumerable<SecurityCommittee>> SearchSecurityCommmittee(string name)
        {
            return await _securityCommitteRepository.SearchSecurityCommmittee(name);
        }

        public async Task<SecurityCommittee> UpdateSecurityCommittee(SecurityCommittee tbl)
        {
            return await _securityCommitteRepository.UpdateSecurityCommittee(tbl);
        }
    }
}
