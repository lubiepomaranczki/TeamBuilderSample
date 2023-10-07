using CommunityToolkit.Maui.Views;
using Prism.Services.Dialogs;

namespace TeamBuilder.Dialogs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTeamMemberDialog : Popup, IDialogAware
    {
        public AddTeamMemberDialog(IDialogParameters parameters)
        {
            InitializeComponent();
            BindingContext = new AddTeamMemberDialogViewModel(this, parameters);
        }

        public void RequestClose(IDialogParameters parameters)
        {
            Close(parameters);
        }
    }
}
