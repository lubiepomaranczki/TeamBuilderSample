using TeamBuilder.DTO.Team.Infrastructure;

namespace TeamBuilder.API.Team.Infrastructure
{
    public static class InMemoryTeamStorage
    {
        private static readonly List<TeamMemberDto> TeamMembers;

        static InMemoryTeamStorage()
        {
            var inactive1 = TeamMemberDto.Create("Mac Miller", "Mac", "Mobile Consultant");
            inactive1.IsActive = false;

            var inactive2 = TeamMemberDto.Create("Amy Jade Whinehouse", "Amy", "Eurockéennes");
            inactive2.IsActive = false;

            TeamMembers = new List<TeamMemberDto>
            {
                TeamMemberDto.Create("John Doe", "Joe", "Senior Xamarin Developer"),
                TeamMemberDto.Create("Alice Chain", "Margot", "Lead Designer"),
                TeamMemberDto.Create("Jack Black", "Blacky", "Full Stack .Net Developer"),
                TeamMemberDto.Create("Gerald Earl Gilluze", "G-Eazy", "Project Manager"),
                inactive1,
                inactive2
            };
        }

        public static Task<List<TeamMemberDto>> GetAllTeamMembersByTeamId(Guid teamId)
        {
            var result = TeamMembers
                .Where(x => x.IsActive)
                .OrderBy(v => v.Name);

            return Task.FromResult(result.ToList());
        }

        public static void AddMember(TeamMemberDto teamMemberDto)
        {
            TeamMembers.Add(teamMemberDto);
        }
    }
}

