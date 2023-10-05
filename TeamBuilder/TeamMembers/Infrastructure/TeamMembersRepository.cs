using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.TeamMembers.Domain;
using TeamBuilder.TeamMembers.Domain.Entities;
using TeamBuilder.TeamMembers.Infrastructure.Models;

namespace TeamBuilder.TeamMembers.Infrastructure
{
    public class TeamMembersRepository : ITeamMembersRepository
    {
        private readonly ITeamMemberClient _teamMemberClient;
        private readonly IMapper _mapper;

        public TeamMembersRepository(ITeamMemberClient teamMemberClient, IMapper mapper)
        {
            _teamMemberClient = teamMemberClient;
            _mapper = mapper;
        }
        public async Task AddTeamMembers(List<TeamMemberEntity> teamMember)
        {
            Guid id = Guid.NewGuid();

            var teamMemberRequest = _mapper.Map<List<TeamMemberRequestModel>>(teamMember);

            await _teamMemberClient.AddTeamMembers(id, teamMemberRequest);
        }
    
        public async Task<List<TeamMemberEntity>> GetTeamMembers()
        {
            Guid guid = Guid.NewGuid();

            var teamMembers = await _teamMemberClient.GetTeamMembers(guid);//TeamMemberResponseModel

            var result = _mapper.Map<List<TeamMemberEntity>>(teamMembers);

            return result;
        }
    }
}
