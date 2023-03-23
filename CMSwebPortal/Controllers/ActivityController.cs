using CMSwebPortal.BusinessLayer.IService;
using CMSwebPortal.Models.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMSwebPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }
        /// <summary>
        /// Get Activity all Data 
        /// </summary>
        /// <returns></returns>
        //Data Retrieve 
        [HttpGet]
        public async Task<ActionResult> GetActivitys()
        {
            return Ok(await _activityService.GetActivitys());
        }
        /// <summary>
        /// Activity New Record Enter
        /// </summary>
        /// <param name="tbl"></param>
        /// <returns></returns>
        //Data Post
        [HttpPost]
        public async Task<ActionResult<Activity>> CreatedMenu(Activity tbl)
        {
            try
            {
                if (tbl == null)
                {
                    return BadRequest();
                }
                var result = await _activityService.AddActivity(tbl);
                return CreatedAtAction(nameof(GetActivitys), new { Id = result.Id }, result);
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
        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivityById(int id)
        {
            var tbl = await _activityService.GetActivityById(id);

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
        [HttpPut("{id}")]
        public async Task<ActionResult<Activity>> UpdateActivity(int id, Activity tbl)
        {
            try
            {
                if (id != tbl.Id)
                {
                    return BadRequest();
                }
                var MenuUpdate = await _activityService.GetActivityById(id);
                if (MenuUpdate == null)
                {
                    return NotFound($"Official Id ={id} Not Found");
                }
                return await _activityService.UpdateActivity(tbl);
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
        [HttpDelete("{id}")]
        public async Task<ActionResult<Activity>> DeleteActivity(int id)
        {
            try
            {
                var MenuDelete = await _activityService.GetActivityById(id);
                if (MenuDelete == null)
                {
                    return NotFound($"Official Id ={id} Not Found");
                }
                return await _activityService.DeleteActivity(id);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Interval Server Error Retrieving data from Databse");

            }

        }
    }
}
