using CMSwebPortal.BusinessLayer.IService;
using CMSwebPortal.Models.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMSwebPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeaderController : ControllerBase
    {
        private readonly IHeaderService _headerService;

        public HeaderController(IHeaderService headerService)
        {
            _headerService = headerService;
        }
        /// <summary>
        /// Get Header all Data 
        /// </summary>
        /// <returns></returns>
        //Data Retrieve 
        [HttpGet]
        public async Task<ActionResult> GetHeaders()
        {
            return Ok(await _headerService.GetHeaders());
        }
        /// <summary>
        /// Header New Record Enter
        /// </summary>
        /// <param name="tbl"></param>
        /// <returns></returns>
        //Data Post
        [HttpPost]
        public async Task<ActionResult<Header>> CreatedMenu(Header tbl)
        {
            try
            {
                if (tbl == null)
                {
                    return BadRequest();
                }
                var result = await _headerService.AddHeader(tbl);
                return CreatedAtAction(nameof(GetHeaders), new { Id = result.Id }, result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Interval Server Error Retrieving data from Databse");
            }
        }
        /// <summary>
        /// Get HeaderRecord by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Header>> GetHeaderById(int id)
        {
            var tbl = await _headerService.GetHeaderById(id);

            if (tbl == null)
            {
                return NotFound();
            }

            return tbl;
        }
        /// <summary>
        /// update Header Record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tbl"></param>
        /// <returns></returns>
        //Data Update
        //   [HttpPut("{id:int}")]
        [HttpPut("{id}")]
        public async Task<ActionResult<Header>> UpdateHeader(int id, Header tbl)
        {
            try
            {
                if (id != tbl.Id)
                {
                    return BadRequest();
                }
                var MenuUpdate = await _headerService.GetHeaderById(id);
                if (MenuUpdate == null)
                {
                    return NotFound($"Official Id ={id} Not Found");
                }
                return await _headerService.UpdateHeader(tbl);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Interval Server Error Retrieving data from Databse");

            }
        }
        /// <summary>
        /// Delete Header 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //Data Delete
        //[HttpDelete("{id:int}}")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Header>> DeleteHeader(int id)
        {
            try
            {
                var MenuDelete = await _headerService.GetHeaderById(id);
                if (MenuDelete == null)
                {
                    return NotFound($"Official Id ={id} Not Found");
                }
                return await _headerService.DeleteHeader(id);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Interval Server Error Retrieving data from Databse");

            }
        }
    }
}
