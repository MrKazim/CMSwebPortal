using CMSwebPortal.BusinessLayer.IService;
using CMSwebPortal.Models.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMSwebPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortMehtodUpsertingController : ControllerBase
    {
        private readonly IUpsertingService _upsertingService;

        public ShortMehtodUpsertingController(IUpsertingService upsertingService)
        {
            _upsertingService = upsertingService;
        }

        /// <summary>
        /// Get Upserting all Data 
        /// </summary>
        /// <returns></returns>
        //Data Retrieve 
        [HttpGet]
        public async Task<ActionResult> GetActivitys()
        {
            return Ok(await _upsertingService.GetActivityUpserting());
        }

        /// <summary>
        /// Upserting Post And Put 
        /// </summary>
        /// <param name="tbl"></param>
        /// <returns></returns>
        //Data Post And Put 
        [HttpPost]
        public async Task<ActionResult<Activity>> AddUpsertingActivity(Activity tbl,int id)
        {
                var result = await _upsertingService.AddUpdateActivityUpserting(tbl, id);
                return CreatedAtAction(nameof(GetActivitys), new { Id = result.Id }, result);
        }
    }
}
