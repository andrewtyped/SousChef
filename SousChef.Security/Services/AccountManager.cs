using CSharpFunctionalExtensions;
using Microsoft.Identity.Client;
using SousChef.Security.Interfaces;
using SousChef.Security.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SousChef.Security.Services
{
    public class AccountManager : IAccountManager, ICurrentUserProvider
    {
        private static string tenant = "souschefb2c.onmicrosoft.com";
        private static string clientId = "d9222aad-e00e-43dd-91d5-47801c7cec48"; //client app id
        private static string PolicySignUpSignIn = "B2C_1_susi";
        private static string PolicyResetPassword = "B2C_1_reset_password";

        private static string ApiEndpoint = "https://localhost44361/api/recipe";

        private static string BaseAuthority = $"https://login.microsoftonline.com/tfp/{tenant}/";
        private static string Authority = $"{BaseAuthority}{PolicySignUpSignIn}";
        private static string AuthorityResetPassword = $"{BaseAuthority}{PolicyResetPassword}";

        //public static string[] Scopes = new[] { "ScopeRead", "ScopeWrite" };
        private static string[] Scopes = new string[] { "https://souschefb2c.onmicrosoft.com/SousChef/ScopeRead", "https://souschefb2c.onmicrosoft.com/SousChef/ScopeWrite"};
        private static string RedirectUri = "ms-app://s-1-15-2-3522139952-3666754034-2991369978-3050587457-3990485999-2909009484-2359225669/";
        private static PublicClientApplication _clientApp = new PublicClientApplication(clientId, Authority);

        public ICurrentUser CurrentUser
        {
            get;
            private set;
        }

        public event EventHandler UserSignedIn;

        public async Task<Result> SignUpSignInAsync()
        {
            AuthenticationResult authResult = null;
            try
            {
                _clientApp.RedirectUri = RedirectUri;

                var user = GetUserByPolicy(_clientApp.Users, PolicySignUpSignIn);

                if (user != null)
                {
                    authResult = await _clientApp.AcquireTokenSilentAsync(Scopes, GetUserByPolicy(_clientApp.Users, PolicySignUpSignIn), Authority, false);
                    this.CurrentUser = new CurrentUser(authResult);
                    this.UserSignedIn?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    authResult = await _clientApp.AcquireTokenAsync(Scopes, GetUserByPolicy(_clientApp.Users, PolicySignUpSignIn), null);
                    this.CurrentUser = new CurrentUser(authResult);
                }

                DisplayBasicTokenInfo(authResult);

                return Result.Ok();
            }
            catch(MsalException ex)
            {
                try
                {
                    if (ex.Message.Contains("AADB2C90118"))
                    {
                        authResult = await _clientApp.AcquireTokenAsync(Scopes, GetUserByPolicy(_clientApp.Users, PolicySignUpSignIn), null);
                    this.CurrentUser = new CurrentUser(authResult);

                        return Result.Ok();
                    }
                    else
                    {
                        Debug.WriteLine($"Error Acquiring Token:{Environment.NewLine}{ex}");

                        return Result.Fail("Error Acquiring Token");
                    }
                }
                catch (Exception ex2)
                {
                    Debug.WriteLine(ex2.ToString());

                    return Result.Fail("Error during password reset");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Users:{string.Join(",", _clientApp.Users.Select(u => u.Identifier))}{Environment.NewLine}Error Acquiring Token:{Environment.NewLine}{ex}");

                return Result.Fail("Error Acquiring Token");
            }
        }
        

        public void SignOut()
        {
            this.CurrentUser = null;

            if(_clientApp.Users.Any())
            {
                try
                {
                    foreach(var user in _clientApp.Users)
                    {
                        _clientApp.Remove(user);
                    }
                }
                catch(MsalException ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }
        }

        private void DisplayBasicTokenInfo(AuthenticationResult authResult)
        {
            var text = "";

            if(authResult != null)
            {
                text += $"Name: {authResult.User.Name}" + Environment.NewLine;
                text += $"Token expires: {authResult.ExpiresOn.ToLocalTime()}" + Environment.NewLine;
                text += $"Access token: {authResult.AccessToken}" + Environment.NewLine;
            }

            Debug.WriteLine(text);
        }

        private IUser GetUserByPolicy(IEnumerable<IUser> users, string policy)
        {
            foreach(var user in users)
            {
                var userId = Base64UrlDecode(user.Identifier.Split('.')[0]);

                if(userId.EndsWith(policy.ToLower()))
                {
                    return user;
                }
            }

            return null;
        }

        private string Base64UrlDecode(string s)
        {
            s = s.Replace('-', '+').Replace('_', '/');
            s = s.PadRight(s.Length + (4 - s.Length % 4) % 4, '=');
            var byteArray = Convert.FromBase64String(s);
            var decoded = Encoding.UTF8.GetString(byteArray, 0, byteArray.Count());
            return decoded;
        }
    }
}

