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
    public class WorkController : ControllerBase
    {
      
        private readonly IWorkService _workService;

        public WorkController( IWorkService workService)
        {
            _workService = workService;
        }

        //Data Retrieve 
        [HttpGet]
        public async Task<ActionResult> GetWork()
        {
            return Ok(await _workService.GetWork());
        }

        //Data Post
        [HttpPost]
        public async Task<ActionResult<Work>> CreatedWork(Work tbl)
        {
            try
            {
                if (tbl == null)
                {
                    return BadRequest();
                }
                var result = await _workService.AddWork(tbl);
                return CreatedAtAction(nameof(GetWork), new { Id = result.Id }, result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Interval Server Error Retrieving data from Databse");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Work>> GetWorkById(int id)
        {
            var tbl = await _workService.GetWorkById(id);

            if (tbl == null)
            {
                return NotFound();
            }

            return tbl;
        }
        //Data Update
        //   [HttpPut("{id:int}")]
        [HttpPut("{id}")]
        public async Task<ActionResult<Work>> UpdateWork(int id, Work tbl)
        {
            try
            {
                if (id != tbl.Id)
                {
                    return BadRequest();
                }
                var wUpdate = await _workService.GetWorkById(id);
                if (wUpdate == null)
                {
                    return NotFound($"Official Id ={id} Not Found");
                }
                return await _workService.UpdateWork(tbl);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Interval Server Error Retrieving data from Databse");

            }
        }
        //Data Delete
        //[HttpDelete("{id:int}}")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Work>> DeleteWork(int id)
        {
            try
            {
                var wDelete = await _workService.GetWorkById(id);
                if (wDelete == null)
                {
                    return NotFound($"Official Id ={id} Not Found");
                }
                return await _workService.DeleteWork(id);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Interval Server Error Retrieving data from Databse");

            }
        }
    }
}
