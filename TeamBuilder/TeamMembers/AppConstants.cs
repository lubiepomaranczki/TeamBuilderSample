using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.TeamMemberList.Application;
using TeamBuilder.TeamMembers.Application.AddTeamMembers;

namespace TeamBuilder.TeamMembers
{
    public class AppConstants
    {
        public static class Navigation
        {
            public const string GoBack = "..";
            public const string TeamMembers = nameof(TeamMembersPage);
            public const string Add = nameof(AddTeamMembersPage);
        }
        public static class ValidationErrors
        {
            public const string MemberAlredyExists = "Member with the same name already exists. Are you sure you want to add this member?";
            public const string EntryValidation = " Name, Nickname and Position should only contain letters";
        }
    }
}
