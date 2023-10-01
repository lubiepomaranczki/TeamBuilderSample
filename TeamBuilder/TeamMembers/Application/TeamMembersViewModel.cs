using System.Collections.ObjectModel;
using System.Windows.Input;
using TeamBuilder.BuildingBlocks.Application;
using TeamBuilder.TeamMembers.Domain;
using TeamBuilder.TeamMembers.Infrastructure;

namespace TeamBuilder.TeamMembers.Application
{
    public class TeamMembersViewModel : BindableBase
    {
        private readonly ITeamMembersRepository _repository;

        public TeamMembersViewModel()
        {
            _repository = new DummyTeamMembersRepository();

            AddNewMembersCommand = new Command(AddNewMembers);

            LoadTeamMembers();
        }

        public ObservableCollection<TeamMemberViewModel> TeamMembers { get; private set; }

        public ICommand AddNewMembersCommand { get; private set; }

        private async void AddNewMembers()
        {
            await Shell.Current.GoToAsync("/Add");
        }

        private async void LoadTeamMembers()
        {
            var teamMembers = await _repository.GetTeamMembers();

            TeamMembers = new ObservableCollection<TeamMemberViewModel>();

            foreach (var member in teamMembers)
            {
                TeamMembers.Add((TeamMemberViewModel)member);
            }
        }
    }
}

