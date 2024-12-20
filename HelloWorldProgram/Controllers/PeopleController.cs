using HelloWorldProgram.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet("sorted")]
        public IActionResult GetSortedPeople()
        {
            List<Person> people = new List<Person>
            {
                new Person { Name = "Ramesh", Age = 33 },
                new Person { Name = "Jensen", Age = 39 },
                new Person { Name = "Nithis", Age = 30 }
            };

            var sortedPeople = people.OrderBy(p => p.Age).ToList();
            return Ok(sortedPeople);
        }
    }
}
