using CMSwebPortal.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSwebPortal.DataLayer.Infrastructure.IRepository
{
    public interface IMenuRepository
    {
        //Get All Menu Data
        Task<IEnumerable<Menu>> GetMenus();

        //Get Menu Data with Specific Id
        Task<Menu> GetMenuById(int id);

        //Add New Menu Data
        Task<Menu> AddMenu(Menu tbl);

        //Update Menu Data
        Task<Menu> UpdateMenu(Menu tbl);

        //Delete Menu Data

        Task<Menu> DeleteMenu(int id);

        //Search Menu Data With Name
        Task<IEnumerable<Menu>> SearchMenu(string name);
    }
}
