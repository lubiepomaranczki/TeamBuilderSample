namespace TeamBuilder.API.Team.Infrastructure
{
    public class InMemoryTeamStorage
    {
        public static List<TeamMemberDb> StaticTeamMembers { get; set; }
        public Task<List<TeamMemberDb>> GetAllTeamMembers()
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

            var result = members.Where(m=>m.IsActive)
                .OrderBy(v => v.Name);

            return Task.FromResult(result.ToList());
        }
        public async Task<List<TeamMemberDb>> GetAllTeamMembersByTeamId(Guid teamId)
        { 
            if( StaticTeamMembers == null)
            {
                StaticTeamMembers = await GetAllTeamMembers();
            }
            return StaticTeamMembers;
        }
        public async Task<List<TeamMemberDb>> AddMembers(List<TeamMemberDb> teamMember)
        {
            foreach (var member in teamMember)
            {
                StaticTeamMembers.Add(member);
            }

            return StaticTeamMembers;
        }
    }
}

