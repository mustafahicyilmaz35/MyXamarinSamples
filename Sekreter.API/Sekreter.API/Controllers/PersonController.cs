using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sekreter.API.Data;
using Sekreter.API.Models;

namespace Sekreter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        IPersonRepository _personRepo;
        public PersonController(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_personRepo.GetAll);
        }

        [HttpPost]
        public IActionResult Create([FromBody]PersonModel person)
        {
            try
            {
                if (person == null || !ModelState.IsValid)
                {
                    return BadRequest("Model is not valid");
                }
                _personRepo.Insert(person);
                return Ok(person);
            }
            catch (Exception)
            {

                return BadRequest("Creeate item failed");
            }
        }
        [HttpPut]
        public IActionResult Edit([FromBody] PersonModel person)
        {
            try
            {
                if (person == null || !ModelState.IsValid)
                {
                    return BadRequest("Model is not valid.");
                }
                var existPerson = _personRepo.Find(person.PersonID);
                if (existPerson == null)
                {
                    return NotFound("Model is not found.");
                }
                _personRepo.Update(person);
                return NoContent();
            }
            catch (Exception)
            {

                return BadRequest("Update failed");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                
                _personRepo.Delete(id);
                return NoContent();
            }
            catch (Exception)
            {

                return BadRequest("Deleted is failed");
            }
        }



    }
}