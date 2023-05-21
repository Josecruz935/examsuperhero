using Microsoft.AspNetCore.Mvc;

namespace superheores.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class homeController : ControllerBase
    {
        context dbcontext;
        public homeController(context db)
        {
          dbcontext = db;
        }

        [HttpGet]
        [Route("ConnDB")]
        public IActionResult ConnDB()
        {
            dbcontext.Database.EnsureCreated();
            return Ok();
        }
    }
}