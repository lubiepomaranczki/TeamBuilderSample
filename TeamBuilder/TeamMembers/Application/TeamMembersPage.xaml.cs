namespace TeamBuilder.TeamMembers.Application;

public partial class TeamMembersPage
{
    public TeamMembersPage()
    {
        InitializeComponent();
        BindingContext = new TeamMembersViewModel();
    }
}
