using CMSwebPortal.BusinessLayer.IService;
using CMSwebPortal.DataLayer.Infrastructure.IRepository;
using CMSwebPortal.Models.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CMSwebPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }
        /// <summary>
        /// Get Menu all Data 
        /// </summary>
        /// <returns></returns>
        //Data Retrieve 
        [HttpGet]
        public async Task<ActionResult> GetMenu()
        {
            return Ok(await _menuService.GetMenus());
        }
        /// <summary>
        /// Menu New Record Enter
        /// </summary>
        /// <param name="tbl"></param>
        /// <returns></returns>
        //Data Post
        [HttpPost]
        public async Task<ActionResult<Menu>> CreatedMenu(Menu tbl)
        {
            try
            {
                if (tbl == null)
                {
                    return BadRequest();
                }
                var result = await _menuService.AddMenu(tbl);
                return CreatedAtAction(nameof(GetMenu), new { Id = result.Id }, result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Interval Server Error Retrieving data from Databse");
            }
        }
        /// <summary>
        /// Get MenuRecord by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Menu>> GetMenuById(int id)
        {
            var tbl = await _menuService.GetMenuById(id);

            if (tbl == null)
            {
                return NotFound();
            }

            return tbl;
        }
        /// <summary>
        /// update Menu Record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tbl"></param>
        /// <returns></returns>
        //Data Update
        //   [HttpPut("{id:int}")]
        [HttpPut("{id}")]
        public async Task<ActionResult<Menu>> UpdateMenu(int id, Menu tbl)
        {
            try
            {
                if (id != tbl.Id)
                {
                    return BadRequest();
                }
                var MenuUpdate = await _menuService.GetMenuById(id);
                if (MenuUpdate == null)
                {
                    return NotFound($"Official Id ={id} Not Found");
                }
                return await _menuService.UpdateMenu(tbl);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Interval Server Error Retrieving data from Databse");

            }
        }
       /// <summary>
       /// Delete Menu 
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        //Data Delete
        //[HttpDelete("{id:int}}")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Menu>> DeleteMenu(int id)
        {
            try
            {
                var MenuDelete = await _menuService.GetMenuById(id);
                if (MenuDelete == null)
                {
                    return NotFound($"Official Id ={id} Not Found");
                }
                return await _menuService.DeleteMenu(id);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Interval Server Error Retrieving data from Databse");

            }
        }
    }
}
