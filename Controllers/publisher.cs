using System.Net;
using Microsoft.AspNetCore.Mvc;
using superheores.models;

namespace superheores.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class publisherController : ControllerBase
    {
        IpublisherService publisherService;
        public publisherController(IpublisherService _publisherService)
        {
            publisherService = _publisherService;
        }

        [HttpPost]
        public async Task<IActionResult> postpublisher([FromBody] publisher newpublisher)
        {
            await publisherService.CreateAsync(newpublisher);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(publisherService.Get());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] publisher updpublisher)
        {
            await publisherService.Update(id, updpublisher);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await publisherService.Delete(id);
            return Ok();
        }
    }
}