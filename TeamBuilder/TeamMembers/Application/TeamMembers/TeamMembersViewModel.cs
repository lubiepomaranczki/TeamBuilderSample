using System.Collections.ObjectModel;
using TeamBuilder.TeamMembers.Domain;
using TeamBuilder.ViewModels.Base;

namespace TeamBuilder.TeamMembers.Application.TeamMembers
{
    public class TeamMembersViewModel : BaseViewModel
    {
        private readonly ITeamMembersRepository _teamMembersRepository;

        public TeamMembersViewModel(ITeamMembersRepository teamMembersRepository)
        {
            try
            {
                _teamMembersRepository = teamMembersRepository;

                LoadTeamMembers();
            }
            catch (Exception ex)
            {
                ShowAlertDialogAsync("Error", ex.Message);
            }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        private async void LoadTeamMembers()
        {
            TeamMemberViewModels = new ObservableCollection<TeamMemberViewModel>();

            var membersResult = await _teamMembersRepository.GetTeamMembers();
            if (membersResult.IsFailure)
            {
                await ShowAlertDialogAsync("Error", membersResult.Error);
                return;
            }

            foreach (var member in membersResult.Value)
            {
                TeamMemberViewModels.Add(member);
            }
        }

        private DelegateCommand _addNewMembersCommand;
        public DelegateCommand AddNewMembersCommand => _addNewMembersCommand ??= new DelegateCommand(async () => await ExecuteAddNewMembersCommand());

        private async Task ExecuteAddNewMembersCommand()
        {
            await NavigationService.NavigateAsync("AddTeamMembersPage");
        }

        private ObservableCollection<TeamMemberViewModel> _teamMemberViewModels;
        public ObservableCollection<TeamMemberViewModel> TeamMemberViewModels
        {
            get => _teamMemberViewModels;
            set => SetProperty(ref _teamMemberViewModels, value);
        }
    }
}

