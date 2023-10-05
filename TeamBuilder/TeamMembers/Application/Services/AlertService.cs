using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamBuilder.TeamMembers.Application.Interfaces;

namespace TeamBuilder.TeamMembers.Application.Services
{
    public class AlertService : IAlertService
    {
        public static AlertService Instance { get; } = new AlertService();

        public AlertService()
        { }

        public async Task<bool> ShowChooserMessage(string message, string acceptButtonText = null, string cancelButtonText = null, string title = null)
        {
            var page = Microsoft.Maui.Controls.Application.Current.MainPage;
            bool result = await page.DisplayAlert(title, message, acceptButtonText, cancelButtonText);
            return result;
        }

        public async Task ShowMessage(string message, string buttonText = null, string title = null)
        {
            var page = Microsoft.Maui.Controls.Application.Current.MainPage;
            await page.DisplayAlert(title, message, buttonText);
        }
    }
}
