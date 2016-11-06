using Appurka.iOS.Views;
using Appurka.ViewModels;
using Appurka.Views;
using System;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(LoginOAuthPage), typeof(LoginOAutPageRenderer))]
namespace Appurka.iOS.Views
{
    public class LoginOAutPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            var auth = new OAuth2Authenticator(
                clientId: LoginOAuthPageViewModel.AuthInformation.ClientId,
                scope: LoginOAuthPageViewModel.AuthInformation.Scope,
                authorizeUrl: new Uri(LoginOAuthPageViewModel.AuthInformation.AuthorizeUrl),
                redirectUrl: new Uri(LoginOAuthPageViewModel.AuthInformation.RedirectUrl));

            auth.Completed += (sender, eventArgs) => {
                // We presented the UI, so it's up to us to dimiss it on iOS.
                var viewModel = (LoginOAuthPageViewModel)Element.BindingContext;
                viewModel.SuccessfulLoginCommand.Execute();

                if (eventArgs.IsAuthenticated)
                {
                    App.Instance.Account = eventArgs.Account;
                    // Use eventArgs.Account to do wonderful things
                    //App.AuthInformation.Token = eventArgs.Account.Properties["access_token"];
                }
                else
                {
                    // The user cancelled
                }
            };

            PresentViewController(auth.GetUI(), true, null);
        }
    }
}