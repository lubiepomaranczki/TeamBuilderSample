using CommunityToolkit.Maui.Views;
using DryIoc;
using Prism.DryIoc;
using Prism.Services.Dialogs;
using TeamBuilder.Dialogs;

namespace TeamBuilder.ViewModels.Base
{
    public abstract class BaseViewModel : BindableBase, INavigationAware
    {
        private static IServiceProvider Container
        {
            get
            {
#if ANDROID
                return MauiApplication.Current.Services;
#elif IOS || MACCATALYST
                return ContainerLocator.Current.CreateServiceProvider();
#endif
            }
        }

        protected readonly INavigationService NavigationService;

        protected BaseViewModel()
        {
            NavigationService = Container.GetService<INavigationService>();
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        protected async Task ShowAlertDialogAsync(string title, string info)
        {
            var dialogParameters = new DialogParameters
            {
                {"Title", title},
                {"Info", info}
            };

            await App.Current.MainPage.ShowPopupAsync(new AlertDialog(dialogParameters));
        }

        protected async Task<bool> ShowQuestionDialogAsync(string title, string info)
        {
            var dialogParameters = new DialogParameters
            {
                {"Title", title},
                {"Info", info}
            };

            var result = (IDialogParameters) await App.Current.MainPage.ShowPopupAsync(new QuestionDialog(dialogParameters));
            return result.ContainsKey("ResultAnswer") && result.GetValue<bool>("ResultAnswer");
        }
    }
}
