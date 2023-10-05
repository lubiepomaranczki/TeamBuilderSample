using TeamBuilder.TeamMemberList.Application;
using TeamBuilder.TeamMembers;
using TeamBuilder.TeamMembers.Application.AddTeamMembers;

namespace TeamBuilder;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(AppConstants.Navigation.Add, typeof(AddTeamMembersPage));
        Routing.RegisterRoute(AppConstants.Navigation.TeamMembers, typeof(TeamMembersPage));
    }
}

