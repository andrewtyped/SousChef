using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SousChef.Security.Interfaces
{
    public interface IAccountManager
    {
        event EventHandler UserSignedIn;

        Task<Result> SignUpSignInAsync();

        void SignOut();
    }
}
