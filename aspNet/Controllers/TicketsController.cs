using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspNet.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TicketsController : ControllerBase
  {
    // Attribute routing
    [HttpGet]
    public IActionResult Get()
    {
      return Ok("Reading tickets...");
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      return Ok($"Reading ticket {id}...");
    }

    [HttpPost]
    public IActionResult Post()
    {
      return Ok($"Creating ticket...");
    }

    [HttpPut]
    public IActionResult Put()
    {
      return Ok($"Updating ticket...");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      return Ok($"Deleting ticket {id}...");
    }
  }
}
