using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TeamBuilder.BuildingBlocks.Application;
using TeamBuilder.TeamMembers.Application.Models;
using TeamBuilder.TeamMembers.Domain;
using TeamBuilder.TeamMembers.Infrastructure;

namespace TeamBuilder.TeamMembers.Application.ViewModel
{
    public class TeamMembersViewModel : BindableBase
    {
        private readonly ITeamMembersRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        private ObservableCollection<TeamMemberViewModel> _teamMembers;

        public ObservableCollection<TeamMemberViewModel> TeamMembers 
        {
            get {  return _teamMembers; }
            set 
            { 
                SetProperty(ref _teamMembers, value); 
            }
        }
        public ICommand AddNewMembersCommand => new Command(AddNewMembers);


        public TeamMembersViewModel(ITeamMembersRepository repository, IMapper mapper, ILogger<TeamMembersViewModel> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        private async void AddNewMembers()
        {
            await Shell.Current.GoToAsync(AppConstants.Navigation.Add);
        }
        public override async Task Initialize()
        {
            await LoadTeamMembers();
        }
        private async Task LoadTeamMembers()
        {
            try
            {
                var teamMembers = await _repository.GetTeamMembers();

                TeamMembers = new ObservableCollection<TeamMemberViewModel>();

                TeamMembers = _mapper.Map<ObservableCollection<TeamMemberViewModel>>(teamMembers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            
        }
    }
}

