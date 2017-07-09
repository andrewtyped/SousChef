using CSharpFunctionalExtensions;
using SousChef.Security.Interfaces;
using SousChef.Shell.Interfaces;
using SousChef.Shell.ViewModels;
using SousChef.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SousChef.UI.ViewModels
{
    public class LoginViewModel : ViewModelBase, ILoginViewModel
    {
        private readonly IAccountManager accountManager;
        private readonly IMainViewModel mainViewModel;
        private readonly INavigator navigator;

        public IAsyncRelayCommand<Result> SignUpSignInCommand
        {
            get;
        }

        public LoginViewModel(IAccountManager accountManager,
                              IRelayCommandFactory relayCommandFactory,
                              IMainViewModel mainViewModel,
                              INavigator navigator)
        {
            if(relayCommandFactory == null)
            {
                throw new ArgumentNullException(nameof(relayCommandFactory));
            }

            this.accountManager = accountManager ?? throw new ArgumentNullException(nameof(accountManager));
            this.mainViewModel = mainViewModel ?? throw new ArgumentNullException(nameof(mainViewModel));
            this.navigator = navigator ?? throw new ArgumentNullException(nameof(navigator));

            this.SignUpSignInCommand = relayCommandFactory.CreateAsyncCommand(OnSignIn, CanSignIn);
        }

        private bool CanSignIn()
        {
            return true;
        }

        private async Task<Result> OnSignIn(CancellationToken cancellationToken)
        {
            if(!CanSignIn())
            {
                return Result.Fail("Cannot currently sign in.");
            }

            var result = await this.accountManager.SignUpSignInAsync();

            if(result.IsSuccess)
            {
                this.navigator.NavigateTo(this.mainViewModel);
                return result;
            }
            else
            {
                //TODO: Show some error text
                return result;
            }
        }
    }
}
