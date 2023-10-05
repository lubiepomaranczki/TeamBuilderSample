using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBuilder.TeamMembers.Application.Interfaces
{
    public interface IAlertService
    {
        Task<bool> ShowChooserMessage(string message, string acceptButtonText = null, string cancelButtonText = null, string title = null);
        Task ShowMessage(string message, string buttonText = null, string title = null);
    }
}
