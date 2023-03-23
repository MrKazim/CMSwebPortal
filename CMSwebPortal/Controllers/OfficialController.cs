using CMSwebPortal.BusinessLayer.IService;
using CMSwebPortal.DataLayer.Infrastructure.IRepository;
using CMSwebPortal.Models.DbModels;
using CMSwebPortal.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CMSwebPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //Assign mutliple Roles to show Pages All Users 
    //Both of Admin and User Show Pages
    //same to you use method -> Roles
    //[Authorize(Roles = "Admin,User")]
    public class OfficialController : ControllerBase
    {
        private readonly IOfficialService _officialService;
        public OfficialController( IOfficialService officialService)
        {
            _officialService = officialService;

        }
        /// <summary>
        /// Get All Data Official Tables
        /// </summary>
        /// <returns></returns>
        //Data Retrieve 
        [HttpGet]
        public async Task<ActionResult> GetOfficial()
        {
            return Ok(await _officialService.GetOfficials());
        }
        /// <summary>
        /// New Record Official
        /// </summary>
        /// <param name="tbl"></param>
        /// <returns></returns>
        //Data Post
        [HttpPost]
        public async Task<ActionResult<GenericApiResponse<Official>>> CreatedEmployee(Official tbl)
        {
            try
            {
                if (tbl == null)
                {
                    return BadRequest();
                }
                var result = await _officialService.AddOfficial(tbl);
                return CreatedAtAction(nameof(GetOfficial), new { }, result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Interval Server Error Retrieving data from Databse");
            }
        }
        /// <summary>
        /// Returns  id through  all Data
        /// </summary>
        /// <param name="Official"></param>
        /// <remarks>
        /// sample request:
        /// 
        /// {
        /// 
        /// "id":1
        ///
        /// }
        /// </remarks>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<GenericApiResponse<Official>>> GetOfficialById(int id)
        {
            var tbl = await _officialService.GetOfficialById(id);

            if (tbl == null)
            {
                return NotFound();
            }

            return tbl;
        }
        //Data Update
        //   [HttpPut("{id:int}")]
        /// <summary>
        /// Update Official Records
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tbl"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<GenericApiResponse<Official>>> UpdateOfficial(int id, Official tbl)
        {
            try
            {
                //if (id != tbl.Id)
                //{
                //    return BadRequest();
                //}
                var Offupdate = await _officialService.GetOfficialById(id);
                if (Offupdate == null)
                {
                    return NotFound($"Official Id ={id} Not Found");
                }
                return await _officialService.UpdateOfficial(tbl);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Interval Server Error Retrieving data from Databse");

            }
        }
        /// <summary>
        /// Delete Official Records
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //Data Delete
        //[HttpDelete("{id:int}}")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<GenericApiResponse<Official>>> DeleteOfficial(int id)
        {
            try
            {
                var offdelete = await _officialService.GetOfficialById(id);
                if (offdelete == null)
                {
                    return NotFound($"Official Id ={id} Not Found");
                }
                return await _officialService.DeleteOfficial(id);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Interval Server Error Retrieving data from Databse");

            }
        }
    }
}
