using TeamBuilder.Functional;
using TeamBuilder.TeamMembers.Application.TeamMembers;

namespace TeamBuilder.TeamMembers.Domain;

public interface ITeamMembersRepository
{
    /// <summary>
    /// This method should allow the client to add team member
    /// </summary>
    /// <param name="teamMemberViewModel">It's object but you can change it to whatever you like :)</param>
    Task<Result> AddTeamMember(TeamMemberViewModel teamMemberViewModel);


    /// <summary>
    /// This method allows client to get GetAllTeamMembers. IList<object> needs to be adjusted. Probably :)
    /// </summary>
    Task<Result<List<TeamMemberViewModel>>> GetTeamMembers();
}
