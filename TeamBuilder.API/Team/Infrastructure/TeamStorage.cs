namespace TeamBuilder.API.Team.Infrastructure
{
    public class InMemoryTeamStorage
    {
        public Task<List<TeamMemberDb>> GetAllTeamMembersByTeamId(Guid teamId)
        {
            var inactive1 = TeamMemberDb.Create("Mac Miller", "Mac", "Mobile Consultant");
            inactive1.IsActive = false;

            var inactive2 = TeamMemberDb.Create("Amy Jade Whinehouse", "Amy", "Eurockéennes");
            inactive2.IsActive = false;


            var members = new List<TeamMemberDb>
            {
                TeamMemberDb.Create("John Doe", "Joe", "Senior Xamarin Developer"),
                TeamMemberDb.Create("Alice Chain", "Margot", "Lead Designer"),
                TeamMemberDb.Create("Jack Black", "Blacky", "Full Stack .Net Developer"),
                TeamMemberDb.Create("Gerald Earl Gilluze", "G-Eazy", "Project Manager"),
                inactive1,
                inactive2
            };

            var result = members
                .OrderBy(v => v.Name);

            return Task.FromResult(result.ToList());
        }

        public void AddMember(object teamMember)
        {
        }
    }
}

