using Microsoft.AspNetCore.Mvc;
using TeamBuilder.API.Team.Infrastructure;

namespace TeamBuilder.API.Team.Application.Controllers;


[ApiController]
[Route("api/v1/[controller]")]
public class TeamController : ControllerBase
{
    private readonly InMemoryTeamStorage _teamStorage;
    private readonly ILogger<TeamController> _logger;

    public TeamController(
        ILogger<TeamController> logger)
    {
        _teamStorage = new InMemoryTeamStorage();
        _logger = logger;
    }

    [HttpGet("{id:Guid}/Members")]
    public async Task<IActionResult> Get(Guid id)
    {
        var response = await _teamStorage.GetAllTeamMembersByTeamId(id);
        return Ok(response);
    }

    [HttpPost("{id:Guid}/AddMember")]
    public async Task<IActionResult> AddTeamMember(Guid id, [FromBody] object teamMember)
    {
        _teamStorage.AddMember(teamMember);
        return Ok();
    }
}