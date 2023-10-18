using TeamBuilder.TeamMembers.Application;
using TeamBuilder.TeamMembers.Domain;

namespace TeamBuilder.TeamMembers.Infrastructure
{
    public class DummyTeamMembersRepository : ITeamMembersRepository
    {
        public Task AddTeamMember(object teamMember)
        {
            throw new NotImplementedException();
        }

        public Task<IList<object>> GetTeamMembers()
        {
            var result = new List<object>
            {
            };

            return Task.FromResult<IList<object>>(result);
        }
    }
}

