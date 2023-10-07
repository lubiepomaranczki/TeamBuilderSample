using Microsoft.AspNetCore.Mvc;
using TeamBuilder.API.Team.Infrastructure;
using TeamBuilder.DTO.Team.Infrastructure;

namespace TeamBuilder.API.Team.Application.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class TeamController : ControllerBase
{
    private readonly ILogger<TeamController> _logger;

    public TeamController(ILogger<TeamController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{id:Guid}/Members")]
    public async Task<IActionResult> Get(Guid id)
    {
        //TODO Regarding point 2) from pdf -> for sending large pieces of data we could use some sort of paging combined with virtualization on client side
        var response = await InMemoryTeamStorage.GetAllTeamMembersByTeamId(id);
        return Ok(response);
    }

    [HttpPost("{id:Guid}/AddMember")]
    public async Task<IActionResult> AddTeamMember(Guid id, [FromBody] TeamMemberDto teamMember)
    {
        InMemoryTeamStorage.AddMember(teamMember);
        return Ok();
    }
}