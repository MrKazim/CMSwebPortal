using CMSwebPortal.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSwebPortal.DataLayer.Infrastructure.IRepository
{
    public interface ISecurityCommitteeRepository
    {
        //Get All SecurityCommitte Data
        Task<IEnumerable<SecurityCommittee>> GetSecurityCommittee();

        //Get SecurityCommmittee Data with Specific Id
        Task<SecurityCommittee> GetSecurityCommitteeById(int id);

        //Add New SecurityCommittee Data
        Task<SecurityCommittee> AddSecurityCommittee(SecurityCommittee tbl);

        //Update SecurityCommittee Data
        Task<SecurityCommittee> UpdateSecurityCommittee(SecurityCommittee tbl);

        //Delete SecurityCommitttee Data

        Task<SecurityCommittee> DeleteSecurityCommittee(int id);

        //Search SecurityCommittee Data With Name
        Task<IEnumerable<SecurityCommittee>> SearchSecurityCommmittee(string name);
    }
}
