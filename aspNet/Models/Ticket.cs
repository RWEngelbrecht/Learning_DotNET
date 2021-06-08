using Microsoft.AspNetCore.Mvc;

namespace aspNet.Controllers
{
  public class Ticket
  {
    [FromQuery(Name="tid")]
    public int TicketId { get; set; }

    [FromRoute(Name="pid")]
    public int ProjectId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }
  }
}