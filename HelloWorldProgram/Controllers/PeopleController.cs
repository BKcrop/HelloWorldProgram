using HelloWorldProgram.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly string _sortedListApiUrl;
        public PeopleController()
        {
            // Fetch the Sorted List API URL from the environment variable
            _sortedListApiUrl = Environment.GetEnvironmentVariable("SORTED_LIST_API_URL");
        }
        [HttpGet("sorted")]
        public IActionResult GetSortedPeople()
        {
            List<Person> people = new List<Person>
            {
                new Person { Name = "Ramesh", Age = 33 },
                new Person { Name = "Jensen", Age = 39 },
                new Person { Name = "Nithis", Age = 30 },
                new Person { Name = "Kannan", Age = 25},
                new Person { Name = "Balaji", Age = 21}
            };

            var sortedPeople = people.OrderBy(p => p.Age).ToList();
            return Ok(sortedPeople);
        }
    }
}
