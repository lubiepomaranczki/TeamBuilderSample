using TeamBuilder.TeamMembers.Application.AddTeamMembers;

namespace TeamBuilder;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("Add", typeof(AddTeamMembersPage));
    }
}

