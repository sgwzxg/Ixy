using Newtonsoft.Json.Linq;
using System;

namespace Ixy.AppService.Authentication.Github
{
    /// <summary>
    /// Contains static methods that allow to extract user's information from a <see cref="T:Newtonsoft.Json.Linq.JObject" />
    /// instance retrieved from Microsoft after a successful authentication process.
    /// http://graph.microsoft.io/en-us/docs/api-reference/v1.0/resources/user
    /// </summary>
    public static class GithubHelper
    {
        /// <summary>
        /// Gets the Microsoft Account user ID.
        /// </summary>
        public static string GetId(JObject user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return user.Value<string>("id");
        }

        /// <summary>
        /// Gets the user's name.
        /// </summary>
        public static string GetLogin(JObject user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return user.Value<string>("login");
        }


        /// <summary>
        /// Gets the user's email address.
        /// </summary>
        public static string GetName(JObject user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return user.Value<string>("name");
        }

        public static string GetUrl(JObject user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return user.Value<string>("url");
        }
    }
}
