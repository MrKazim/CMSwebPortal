using CMSwebPortal.Models.DbModels;
using CMSwebPortal.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSwebPortal.BusinessLayer.IService
{
    public interface IOfficialService
    {
        //Get All Official Data
        Task<IEnumerable<Official>> GetOfficials();

        //Get Official Data with Specific Id
        Task<GenericApiResponse<Official>> GetOfficialById(int id);

        //Add New Official Data
        Task<GenericApiResponse<Official>> AddOfficial(Official tbl);

        //Update Official Data

        Task<GenericApiResponse<Official>> UpdateOfficial(Official tbl);

        //Delete Official Data

        Task<GenericApiResponse<Official>> DeleteOfficial(int id);

        //Search Official Data With Name
        Task<IEnumerable<Official>> SearchOfficial(string name);
    }
}
