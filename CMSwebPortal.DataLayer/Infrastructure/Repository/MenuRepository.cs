using CMSwebPortal.DataLayer.Infrastructure.IRepository;
using CMSwebPortal.Models.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSwebPortal.DataLayer.Infrastructure.Repository
{
    public class MenuRepository:IMenuRepository
    {
        private readonly ApplicationDbContext _db;
        public MenuRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Menu> AddMenu(Menu tbl)
        {
            var obj = await _db.Menu.AddAsync(tbl);
            _db.SaveChanges();
            return obj.Entity;
        }

        public async Task<Menu> DeleteMenu(int id)
        {
            var result = await _db.Menu.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (result != null)
            {
                // removes data
                _db.Menu.Remove(result);
                await _db.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Menu> GetMenuById(int id)
        {
            return await _db.Menu.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Menu>> GetMenus()
        {
            try
            {
                return await _db.Menu.ToListAsync();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Menu>> SearchMenu(string name)
        {

            IQueryable<Menu> query = _db.Menu;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.Title.Contains(name));
            }
            return await query.ToListAsync();
        }

        public async Task<Menu> UpdateMenu(Menu tbl)
        {

            var result = await _db.Menu.FirstOrDefaultAsync(a => a.Id == tbl.Id);
            if (result != null)
            {
                result.Label = tbl.Label;
                result.Title = tbl.Title;
                result.Action = tbl.Action;
                result.Controller = tbl.Controller;
                result.ParentId = tbl.ParentId;
                result.Footer = tbl.Footer;
                result.Admin = tbl.Admin;
                result.Detail = tbl.Detail;
                result.CreatedBy = tbl.CreatedBy;
                result.ModifiedBy = tbl.ModifiedBy;
                result.CreatedDate = tbl.CreatedDate;
                result.ModifiedDate = tbl.ModifiedDate;
                result.isActive = tbl.isActive;
                await _db.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
