using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.TeamMembers.Infrastructure.Models;
using TeamBuilder.TeamMembers.Infrastructure.Models.Responses;

namespace TeamBuilder.TeamMembers.Infrastructure
{
    public interface ITeamMemberClient
    {
        [Post("/api/v1/Team/{id}/AddMembers")]
        public Task AddTeamMembers(Guid id, List<TeamMemberRequestModel> teamMembers);

        [Get("/api/v1/Team/{id}/Members")]
        public Task<List<TeamMemberResponseModel>> GetTeamMembers(Guid id);
    }
}
