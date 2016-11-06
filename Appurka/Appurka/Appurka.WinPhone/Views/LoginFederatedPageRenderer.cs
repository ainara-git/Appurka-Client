using Appurka.ViewModels;
using Appurka.Views;
using Appurka.WinPhone.Views;
using System;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinRT;

[assembly: ExportRenderer(typeof(LoginOAuthPage), typeof(LoginOAutPageRenderer))]
namespace Appurka.WinPhone.Views
{
    public class LoginOAutPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            var viewModel = (LoginOAuthPageViewModel)Element.BindingContext;

            var auth = new OAuth2Authenticator(
                clientId: LoginOAuthPageViewModel.AuthInformation.ClientId,
                scope: LoginOAuthPageViewModel.AuthInformation.Scope,
                authorizeUrl: new Uri(LoginOAuthPageViewModel.AuthInformation.AuthorizeUrl),
                redirectUrl: new Uri(LoginOAuthPageViewModel.AuthInformation.RedirectUrl));

            auth.Completed += (sender, eventArgs) =>
            {
                if (eventArgs.IsAuthenticated)
                {
                    // Use eventArgs.Account to do wonderful things
                    //App.AuthInformation.Token = eventArgs.Account.Properties["access_token"];
                    
                    viewModel.SuccessfulLoginCommand.Execute();
                    AccountStore.Create().Save(eventArgs.Account, LoginOAuthPageViewModel.AuthInformation.Name);
                }
                else
                {
                    // The user cancelled
                }
            };

            var url = auth.GetInitialUrlAsync();
        }
    }
}