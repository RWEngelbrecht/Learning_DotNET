using Microsoft.AspNetCore.Mvc;

namespace aspNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController: ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Reading projects...");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok($"Reading project {id}...");
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok($"Creating project...");
        }

        [HttpPut]
        public IActionResult Put()
        {
            return Ok($"Updating project...");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Deleting project {id}...");
        }
    }
}