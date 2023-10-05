using TeamBuilder.TeamMembers.Domain.Entities;

namespace TeamBuilder.TeamMembers.Domain;

public interface ITeamMembersRepository
{
    /// <summary>
    /// This method should allow the client to add team member
    /// </summary>
    /// <param name="teamMember">It's object but you can change it to whatever you like :)</param>
    Task AddTeamMembers(List<TeamMemberEntity> teamMember);


    /// <summary>
    /// This method allows client to get GetAllTeamMembers. IList<object> needs to be adjusted. Probably :)
    /// </summary>
    Task<List<TeamMemberEntity>> GetTeamMembers();
}
