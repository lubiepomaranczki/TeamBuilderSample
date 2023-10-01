using TeamBuilder.TeamMembers.Application;

namespace TeamBuilder.TeamMemberList.Application;

public partial class TeamMembersPage : ContentPage
{
    public TeamMembersPage()
    {
        InitializeComponent();
        BindingContext = new TeamMembersViewModel();
    }
}
