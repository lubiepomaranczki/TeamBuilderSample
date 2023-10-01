namespace TeamBuilder.API.Team.Infrastructure
{
    public class TeamMemberDb
    {
        public string Name { get; set; }
        public string NickName { get; set; }
        public string? PhoneNumber { get; set; }
        public string Position { get; set; }

        public bool IsActive { get; set; }

        internal static TeamMemberDb Create(string name, string nickName, string position)
        {
            return new TeamMemberDb
            {
                Name = name,
                NickName = nickName,
                Position = position,
                PhoneNumber = "+48-000-555-999-2",
                IsActive = true
            };
        }
    }
}

