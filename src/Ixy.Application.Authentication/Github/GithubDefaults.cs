namespace Ixy.Application.Authentication.Github
{
    public static class GithubDefaults
    {
        public const string AuthenticationScheme = "Github";

        public static readonly string AuthorizationEndpoint = "https://github.com/login/oauth/authorize";

        public static readonly string TokenEndpoint = "https://github.com/login/oauth/access_token";

        public static readonly string UserInformationEndpoint = "https://api.github.com/user";
    }
}
