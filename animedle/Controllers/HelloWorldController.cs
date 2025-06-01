using Microsoft.AspNetCore.Mvc;

namespace animedle.Controllers
{
 [ApiController]
 [Route("api/[controller]")]
 public class HelloController : ControllerBase
 {
   [HttpGet]
   public IActionResult Get()
   {
     return new JsonResult("Hello World!:");
   }
 }
}