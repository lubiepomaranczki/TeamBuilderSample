namespace TeamBuilder.TeamMembers.Application
{
    public class TeamMemberViewModel
    {
        private TeamMemberViewModel(string name, string nickName, string position,
             string? phoneNumber)
        {
            Name = name;
            NickName = nickName;
            Position = position;
            PhoneNumber = phoneNumber;
        }

        public string Name { get; }
        public string NickName { get; }
        public string Position { get; }
        public string? PhoneNumber { get; }

        public static TeamMemberViewModel Create(string name, string nickName, string position, string? phoneNumber = null)
        {
            return new(name, nickName, position, phoneNumber);
        }
    }
}

