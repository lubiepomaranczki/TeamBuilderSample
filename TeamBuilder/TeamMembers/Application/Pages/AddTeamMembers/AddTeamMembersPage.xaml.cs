using TeamBuilder.TeamMembers.Application.ViewModels;

namespace TeamBuilder.TeamMembers.Application.AddTeamMembers;

public partial class AddTeamMembersPage : ContentPage
{
    private readonly AddTeamMembersViewModel _viewModel;
    public AddTeamMembersPage(AddTeamMembersViewModel viewModel)
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
