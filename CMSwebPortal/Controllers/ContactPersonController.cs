using CMSwebPortal.BusinessLayer.IService;
using CMSwebPortal.Models.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMSwebPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactPersonController : ControllerBase
    {
        private readonly IContactPersonService _contactPersonService;

        public ContactPersonController(IContactPersonService contactPersonService)
        {
            _contactPersonService = contactPersonService;
        }
        /// <summary>
        /// Get ContactPerson all Data 
        /// </summary>
        /// <returns></returns>
        //Data Retrieve 
        [HttpGet]
        public async Task<ActionResult> GetContactPersons()
        {
            return Ok(await _contactPersonService.GetContactPersons());
        }
        /// <summary>
        /// ContactPerson New Record Enter
        /// </summary>
        /// <param name="tbl"></param>
        /// <returns></returns>
        //Data Post
        [HttpPost]
        public async Task<ActionResult<ContactPerson>> CreatedContactPerson(ContactPerson tbl)
        {
            try
            {
                if (tbl == null)
                {
                    return BadRequest();
                }
                var result = await _contactPersonService.AddContactPerson(tbl);
                return CreatedAtAction(nameof(GetContactPersons), new { Id = result.Id }, result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Interval Server Error Retrieving data from Databse");
            }
        }
        /// <summary>
        /// Get ContactPerson Record by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactPerson>> GetContactPersonById(int id)
        {
            var tbl = await _contactPersonService.GetContactPersonById(id);

            if (tbl == null)
            {
                return NotFound();
            }

            return tbl;
        }
        /// <summary>
        /// update ContactPerson Record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tbl"></param>
        /// <returns></returns>
        //Data Update
        //   [HttpPut("{id:int}")]
        [HttpPut("{id}")]
        public async Task<ActionResult<ContactPerson>> UpdateContactPerson(int id, ContactPerson tbl)
        {
            try
            {
                if (id != tbl.Id)
                {
                    return BadRequest();
                }
                var MenuUpdate = await _contactPersonService.GetContactPersonById(id);
                if (MenuUpdate == null)
                {
                    return NotFound($"Official Id ={id} Not Found");
                }
                return await _contactPersonService.UpdateContactPerson(tbl);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Interval Server Error Retrieving data from Databse");

            }
        }
        /// <summary>
        /// Delete ContactPerson Record 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //Data Delete
        //[HttpDelete("{id:int}}")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContactPerson>> DeleteContactPerson(int id)
        {
            try
            {
                var MenuDelete = await _contactPersonService.GetContactPersonById(id);
                if (MenuDelete == null)
                {
                    return NotFound($"Official Id ={id} Not Found");
                }
                return await _contactPersonService.DeleteContactPerson(id);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Interval Server Error Retrieving data from Databse");

            }
        }
    }
}

