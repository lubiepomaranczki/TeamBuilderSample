using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBuilder.TeamMembers.Infrastructure.Models
{
    public class TeamMemberRequestModel
    {
        public string Name { get; set; }
        public string NickName { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
    }
}
