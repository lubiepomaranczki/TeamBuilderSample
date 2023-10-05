using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.TeamMembers.Application.Models;

namespace TeamBuilder.TeamMembers.Application.Validater
{
    public class TeamMemberValidator : AbstractValidator<TeamMemberViewModel>
    {
        public TeamMemberValidator()
        {
            RuleFor(n => n.Name).NotEmpty().MaximumLength(64).Matches("^[a-zA-Z ]*$");
            RuleFor(n => n.NickName).NotEmpty().MaximumLength(64).Matches("^[a-zA-Z]*$");
            RuleFor(n => n.Position).NotEmpty().MaximumLength(64).Matches("^[a-zA-Z]*$");
        }
    }
}
