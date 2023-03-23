using DbFirstApproach.BusinessLayer.IService;
using DbFirstApproach.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbFirstApproach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficialController : ControllerBase
    {
        private readonly IOfficialService _officialService;

        public OfficialController(IOfficialService activityService)
        {
            _officialService = activityService;
        }
        /// <summary>
        /// Get Activity all Data 
        /// </summary>
        /// <returns></returns>
        //Data Retrieve 
        [HttpGet("Get All Record Officials")]
        public async Task<ActionResult> GetOfficials()
        {
            return Ok(await _officialService.GetOfficials());
        }
        /// <summary>
        /// Activity New Record Enter
        /// </summary>
        /// <param name="tbl"></param>
        /// <returns></returns>
        //Data Post
        [HttpPost("Add new Record Into Officials")]
        public async Task<ActionResult<Official>> CreatedOfficial(Official tbl)
        {
            try
            {
                if (tbl == null)
                {
                    return BadRequest();
                }
                var result = await _officialService.AddOfficial(tbl);
                return CreatedAtAction(nameof(GetOfficials), new { Id = result.Id }, result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Interval Server Error Retrieving data from Databse");
            }
        }
        /// <summary>
        /// Get ActivityRecord by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Get Official Record Through Id")]
        public async Task<ActionResult<Official>> GetOfficialById(int id)
        {
            var tbl = await _officialService.GetOfficialById(id);

            if (tbl == null)
            {
                return NotFound();
            }

            return tbl;
        }
        /// <summary>
        /// update Activity Record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tbl"></param>
        /// <returns></returns>
        //Data Update
        //   [HttpPut("{id:int}")]
        [HttpPut("Update Official Record")]
        public async Task<ActionResult<Official>> UpdateOfficial(int id, Official tbl)
        {
            try
            {
                if (id != tbl.Id)
                {
                    return BadRequest();
                }
                var MenuUpdate = await _officialService.GetOfficialById(id);
                if (MenuUpdate == null)
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
        /// Delete Activity 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //Data Delete
        //[HttpDelete("{id:int}}")]
        [HttpDelete("Delete Official Record")]
        public async Task<ActionResult<Official>> DeleteOfficial(int id)
        {
            try
            {
                var MenuDelete = await _officialService.GetOfficialById(id);
                if (MenuDelete == null)
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
