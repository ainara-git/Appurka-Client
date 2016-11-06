using Android.App;
using Appurka.Droid.Views;
using Appurka.ViewModels;
using Appurka.Views;
using System;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(LoginOAuthPage), typeof(LoginOAutPageRenderer))]
namespace Appurka.Droid.Views
{
    public class LoginOAutPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            // this is a ViewGroup - so should be able to load an AXML file and FindView<>
            var activity = this.Context as Activity;

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
                    App.Instance.Account = eventArgs.Account;
                    viewModel.SuccessfulLoginCommand.Execute();
                    AccountStore.Create().Save(eventArgs.Account, LoginOAuthPageViewModel.AuthInformation.Name);
                }
                else
                {
                    viewModel.CancelLoginCommand.Execute();
                }
            };

            activity.StartActivity(auth.GetUI(activity));
        }
    }
}