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
                TeamMemberViewModel.Create("John Doe", "Joe", "Senior Xamarin Developer"),
                TeamMemberViewModel.Create("Alice Chain", "Margot", "Lead Designer"),
                TeamMemberViewModel.Create("Jack Black", "Blacky", "Full Stack .Net Developer"),
                TeamMemberViewModel.Create("Gerald Earl Gilluze", "G-Eazy", "Project Manager"),
            };

            return Task.FromResult<IList<object>>(result);
        }
    }
}

