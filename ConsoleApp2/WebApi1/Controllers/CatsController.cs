using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi1.Controllers
{
    [Route("api/cats")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        public IActionResult Get()
        {
            var cat = new Cat();
            cat.Color = "Black";
            cat.Weight = 10;

            cat.Walk()

            return Ok(cat);
        }
    }
}
