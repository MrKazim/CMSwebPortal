using CMSwebPortal.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSwebPortal.BusinessLayer.IService
{
    public interface IHeaderService
    {
        //Get All Header Data
        Task<IEnumerable<Header>> GetHeaders();

        //Get Header Data with Specific Id
        Task<Header> GetHeaderById(int id);

        //Add New Header Data
        Task<Header> AddHeader(Header tbl);

        //Update Header Data
        Task<Header> UpdateHeader(Header tbl);

        //Delete Header Data

        Task<Header> DeleteHeader(int id);

        //Search Header Data With Name
        Task<IEnumerable<Header>> SearchHeader(string name);
    }
}
