using System;
using Android.App;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Authenticator.Droid;
using Xamarin.Auth;
using Appurka.Views;
using Appurka.ViewModels;
using Appurka.Models;

[assembly: ExportRenderer(typeof(LoginOAuthPage), typeof(LoginOAutPageRenderer))]
namespace Authenticator.Droid
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
                    // Use eventArgs.Account to do wonderful things
                    //App.AuthInformation.Token = eventArgs.Account.Properties["access_token"];
                    
                    viewModel.SuccessfulLoginCommand.Execute();
                }
                else
                {
                    // The user cancelled
                }
            };

            activity.StartActivity(auth.GetUI(activity));
        }
    }
}