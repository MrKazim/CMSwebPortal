using CMSwebPortal.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSwebPortal.DataLayer.Infrastructure.IRepository
{
    public interface IWorkRepository
    {
        //Get All Work Data
        Task<IEnumerable<Work>> GetWork();

        //Get Work Data with Specific Id
        Task<Work> GetWorkById(int id);

        //Add New Work Data
        Task<Work> AddWork(Work tbl);

        //Update Work Data
        Task<Work> UpdateWork(Work tbl);

        //Delete Work Data

        Task<Work> DeleteWork(int id);

        //Search Work Data With Name
        Task<IEnumerable<Work>> SearchWork(string name);
    }
}
