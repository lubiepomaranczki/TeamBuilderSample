using System.Text;
using System.Text.Json;
using TeamBuilder.DTO.Team.Infrastructure;
using TeamBuilder.Functional;
using TeamBuilder.TeamMembers.Application.TeamMembers;
using TeamBuilder.TeamMembers.Domain;

namespace TeamBuilder.TeamMembers.Infrastructure
{
    public class TeamMembersRepository : ITeamMembersRepository
    {
        private readonly string _url;
        private readonly JsonSerializerOptions _serializerOptions;

        public TeamMembersRepository()
        {
            _url = DeviceInfo.Platform == DevicePlatform.Android
                ? "https://10.0.2.2:7222/api/v1/Team"
                : "https://localhost:7222/api/v1/Team";

            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<Result> AddTeamMember(TeamMemberViewModel teamMemberViewModel)
        {
            try
            {
                string json = JsonSerializer.Serialize(teamMemberViewModel.ToDto(), _serializerOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                using var client = new HttpClient(GetInsecureHandler());
                var response = await client.PostAsync($"{_url}/{Guid.NewGuid()}/AddMember", content);

                return response.IsSuccessStatusCode ? Result.Ok() : Result.Fail($"Error: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        public async Task<Result<List<TeamMemberViewModel>>> GetTeamMembers()
        {
            var teamMemberViewModels = new List<TeamMemberViewModel>();

            try
            {
                using var client = new HttpClient(GetInsecureHandler());
                var response = await client.GetAsync($"{_url}/{Guid.NewGuid()}/Members");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var teamMemberDtos = JsonSerializer.Deserialize<List<TeamMemberDto>>(content, _serializerOptions);
                    teamMemberDtos?.ForEach(x => teamMemberViewModels.Add(x.ToViewModel()));
                }
                else
                {
                    return Result.Fail<List<TeamMemberViewModel>>($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                return Result.Fail<List<TeamMemberViewModel>>(ex.Message);
            }

            return Result.Ok(teamMemberViewModels);
        }

        private HttpClientHandler GetInsecureHandler()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (_, cert, _, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }
    }
}

