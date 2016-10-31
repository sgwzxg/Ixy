﻿namespace Ixy.Application.Authentication.Weibo
{
    public static class WeiboDefaults
    {
        public const string AuthenticationScheme = "Weibo";

        public static readonly string AuthorizationEndpoint = "https://api.weibo.com/oauth2/authorize";

        public static readonly string TokenEndpoint = "https://api.weibo.com/oauth2/access_token";

        public static readonly string UserInformationEndpoint = "https://api.weibo.com/oauth2/user";
    }
}
