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
        // [HttpGet]
        // [Route("/api/projects/{pid}/tickets")]
        // public IActionResult GetProjectTicket(int pid, [FromQuery] int tid) //model binding from route and query
        // {
        //     if(tid == 0)
        //         return Ok($"Reading all tickets in project {pid}");
        //     return Ok($"Reading project {pid}, ticket {tid}");
        // }
        [HttpGet]
        [Route("/api/projects/{pid}/tickets")]
        public IActionResult GetProjectTicket([FromQuery]Ticket ticket) //model binding from route and query
        {
            if(ticket == null)
                return BadRequest("Not all needed parameters were provided...");
            else if(ticket.TicketId == 0)
                return Ok($"Reading all tickets in project {ticket.ProjectId}");
            return Ok($"Reading project {ticket.ProjectId}, ticket {ticket.TicketId}, title: {ticket.Title}, description: {ticket.Description}");
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