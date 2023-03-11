using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet("all")]
        public ActionResult<IEnumerable<Person>> GetAll()
        {
            return Ok(PersonInstanceStorage.personRepository.GetPerson());
        }

        [HttpGet("by id")]
        public ActionResult<IEnumerable<Person>> GetById(int id)
        {
            return PersonInstanceStorage.personRepository.GetPersonById();
        }

        [HttpPost("Create")]

        public ActionResult<Person> Create(Person person)
        {
            return Create(person);
        }

        [HttpDelete("delete")]

        public ActionResult<MessageResponse> Delete(int id)
        {
            bool sucsess = PersonInstanceStorage.personRepository.DeletePerson(id);
            if (sucsess)
            {
                return Ok(new MessageResponse
                {
                    Message = "Person has deleted!"
                });
            }
            else
            {
                return BadRequest(new MessageResponse
                {
                    Message = "Person is not deleted!"
                });
            }
        }

       



    }

}
