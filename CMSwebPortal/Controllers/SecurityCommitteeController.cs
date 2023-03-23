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
    public class SecurityCommitteeController : ControllerBase
    {
     
        private readonly ISecurityCommitteeService _securityCommitteeService;

        public SecurityCommitteeController( ISecurityCommitteeService securityCommitteeService)
        {
           
            _securityCommitteeService = securityCommitteeService;
        }

        //Data Retrieve 
        [HttpGet]
        public async Task<ActionResult> GetSecurityCommittee()
        {
            return Ok(await _securityCommitteeService.GetSecurityCommittee());
        }

        //Data Post
        [HttpPost]
        public async Task<ActionResult<SecurityCommittee>> CreatedSecurityCommittee(SecurityCommittee tbl)
        {
            try
            {
                if (tbl == null)
                {
                    return BadRequest();
                }
                var result = await _securityCommitteeService.AddSecurityCommittee(tbl);
                return CreatedAtAction(nameof(GetSecurityCommittee), new { Id = result.Id }, result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Interval Server Error Retrieving data from Databse");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SecurityCommittee>> GetSecurityCommitteeById(int id)
        {
            var tbl = await _securityCommitteeService.GetSecurityCommitteeById(id);

            if (tbl == null)
            {
                return NotFound();
            }

            return tbl;
        }
        //Data Update
        //   [HttpPut("{id:int}")]
        [HttpPut("{id}")]
        public async Task<ActionResult<SecurityCommittee>> UpdateSecurityCommittee(int id, SecurityCommittee tbl)
        {
            try
            {
                if (id != tbl.Id)
                {
                    return BadRequest();
                }
                var SecurityCommitteeUpdate = await _securityCommitteeService.GetSecurityCommitteeById(id);
                if (SecurityCommitteeUpdate == null)
                {
                    return NotFound($"Official Id ={id} Not Found");
                }
                return await _securityCommitteeService.UpdateSecurityCommittee(tbl);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Interval Server Error Retrieving data from Databse");

            }
        }
        //Data Delete
        //[HttpDelete("{id:int}}")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<SecurityCommittee>> DeleteSecurityCommittee(int id)
        {
            try
            {
                var SecurityCommitteeDelete = await _securityCommitteeService.GetSecurityCommitteeById(id);
                if (SecurityCommitteeDelete == null)
                {
                    return NotFound($"Official Id ={id} Not Found");
                }
                return await _securityCommitteeService.DeleteSecurityCommittee(id);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Interval Server Error Retrieving data from Databse");

            }
        }
    }
}
