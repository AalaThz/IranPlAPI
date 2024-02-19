using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Iranpl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        [HttpGet] public IActionResult Get()
        {
            return Ok(DateTime.Now);
        }
    }
}
