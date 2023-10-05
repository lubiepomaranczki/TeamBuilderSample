using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TeamBuilder.BuildingBlocks.Application;
using TeamBuilder.TeamMembers.Application.Interfaces;
using TeamBuilder.TeamMembers.Application.Models;
using TeamBuilder.TeamMembers.Application.Validater;
using TeamBuilder.TeamMembers.Domain;
using TeamBuilder.TeamMembers.Domain.Entities;

namespace TeamBuilder.TeamMembers.Application.ViewModels
{
    public class AddTeamMembersViewModel : BindableBase
    {
        private readonly ITeamMembersRepository _repository;
        private readonly IAlertService _alertService; 
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        private ObservableCollection<TeamMemberViewModel> _newMembers;
        private TeamMemberViewModel _teamMember;

        public ObservableCollection<TeamMemberViewModel> NewMembers 
        {
            get { return _newMembers; }
            set 
            { 
                SetProperty(ref _newMembers, value); 
            }
        }
        
        public TeamMemberViewModel TeamMember 
        {
            get { return _teamMember; }
            set 
            { 
                SetProperty(ref _teamMember, value);
            }
        }
        public ICommand AddNewMemberCommand => new Command<TeamMemberViewModel>(AddNewMember);
        public ICommand SaveMembersCommand => new Command(SaveMembers);

        public AddTeamMembersViewModel(ITeamMembersRepository repository, IAlertService alertService, IMapper mapper, ILogger<AddTeamMembersViewModel> logger)
        {
            _repository = repository;
            _alertService = alertService;
            _mapper = mapper;
            _logger = logger;
        }

        public override async Task Initialize()
        {
            NewMembers = new ObservableCollection<TeamMemberViewModel>();
            TeamMember = new TeamMemberViewModel();
        }

        private async void AddNewMember(TeamMemberViewModel teamMember)
        {
            try
            {
                var teamMemberIsValid = await IsTeamMemberValid(teamMember);

                if (teamMemberIsValid)
                {
                    NewMembers.Add(teamMember);
                    TeamMember = new TeamMemberViewModel();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            
        }
        private async Task<bool> IsTeamMemberValid(TeamMemberViewModel teamMember)
        {
            try
            {           
                TeamMemberValidator validator = new TeamMemberValidator();

                var result = validator.Validate(teamMember);

                if (result.Errors.Count != 0)
                {
                    await _alertService.ShowMessage(result.Errors.FirstOrDefault().ErrorMessage + AppConstants.ValidationErrors.EntryValidation, "Ok", "Error");
                    return false;
                }
                else
                {
                    var teamMembers = await _repository.GetTeamMembers();

                    if (teamMembers.Any(x => x.Name == teamMember.Name))
                    {
                        var res = await _alertService.ShowChooserMessage(AppConstants.ValidationErrors.MemberAlredyExists, "Yes", "No", "Error");

                        if (res)
                        {
                            return true;
                        }
                    }
               
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }
        private async void SaveMembers()
        {
            try
            {
                var teamMember = _mapper.Map<List<TeamMemberEntity>>(NewMembers);

                await _repository.AddTeamMembers(teamMember);

                await Shell.Current.GoToAsync(AppConstants.Navigation.GoBack);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }
    }
}
