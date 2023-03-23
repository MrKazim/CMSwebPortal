using CMSwebPortal.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSwebPortal.DataLayer.Infrastructure.IRepository
{
    public interface IOfficialRepository
    {
        //Get All Official Data
        Task<IEnumerable<Official>> GetOfficials();

        //Get Official Data with Specific Id
        Task<Official> GetOfficialById(int id);

        //Add New Official Data
        Task<Official> AddOfficial(Official tbl);

        //Update Official Data
        Task<Official> UpdateOfficial(Official tbl);

        //Delete Official Data

        Task<Official> DeleteOfficial(int id);

        //Search Official Data With Name
        Task<IEnumerable<Official>> SearchOfficial(string name);
    }
}
