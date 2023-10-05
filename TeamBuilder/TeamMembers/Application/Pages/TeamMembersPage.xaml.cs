using TeamBuilder.TeamMembers.Application;
using TeamBuilder.TeamMembers.Application.ViewModel;

namespace TeamBuilder.TeamMemberList.Application;

public partial class TeamMembersPage : ContentPage
{
    private readonly TeamMembersViewModel _viewModel;
    public TeamMembersPage(TeamMembersViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.Initialize();
    }
}
