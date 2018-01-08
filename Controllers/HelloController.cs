using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace hello_world
{
  [Route("api/[Controller]")]
  [EnableCors("MyPolicy")]
  public class HelloController : Controller
  {
    [HttpGet]
    public IActionResult Greetings()
    {
      return Ok("Hello from ASP.NET Core Web API.");
    }
  }
}
