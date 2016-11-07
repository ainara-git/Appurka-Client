namespace Appurka.Models
{
    public class AuthInformation
    {
        public const string FACEBOOK = "facebook";
        public static AuthInformation Facebook;

        static AuthInformation()
        {
            Facebook = new AuthInformation()
            {
                Name = FACEBOOK,
                ClientId = "195056067600094",
                Scope = "email",
                AuthorizeUrl = "https://m.facebook.com/dialog/oauth",
                RedirectUrl = "https://www.facebook.com/connect/login_success.html",
                AccessTokenUrl = "https://m.facebook.com/dialog/oauth/token"
            };
        }

        public string Name { get; set; }
        public string ClientId { get; set; }
        public string Scope { get; set; }
        public string AuthorizeUrl { get; set; }
        public string RedirectUrl { get; set; }
        public string AccessTokenUrl { get; set; }
    }
}
