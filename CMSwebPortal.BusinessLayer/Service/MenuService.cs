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
    public class MenuService:IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<Menu> AddMenu(Menu tbl)
        {
            return await _menuRepository.AddMenu(tbl);
        }

        public async Task<Menu> DeleteMenu(int id)
        {
            return await _menuRepository.DeleteMenu(id);
        }

        public async Task<Menu> GetMenuById(int id)
        {
            return await _menuRepository.GetMenuById(id);
        }

        public async Task<IEnumerable<Menu>> GetMenus()
        {
            return await _menuRepository.GetMenus();
        }

        public async Task<IEnumerable<Menu>> SearchMenu(string name)
        {
            return await _menuRepository.SearchMenu(name);
        }

        public async Task<Menu> UpdateMenu(Menu tbl)
        {
            return await _menuRepository.UpdateMenu(tbl);
        }
    }
}
