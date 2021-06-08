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

        /// <summary>
        /// api/projects/{pid}/tickets?tid={tid}
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/projects/{pid}/tickets")]
        public IActionResult GetProjectTicket(int pid, [FromQuery] int tid) //model binding from route and query
        {
            if(tid == 0)
                return Ok($"Reading all tickets in project {pid}");
            return Ok($"Reading project {pid}, ticket {tid}");
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