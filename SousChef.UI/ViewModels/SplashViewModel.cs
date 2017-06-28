using SousChef.Shell.Interfaces;
using SousChef.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SousChef.UI.ViewModels
{
    public class SplashViewModel : ISplashViewModel
    {
        private readonly INavigator navigator;

        public SplashViewModel(INavigator navigator)
        {
            this.navigator = navigator ?? throw new ArgumentNullException(nameof(navigator));

            Task.Delay(2000);

          //  navigator.NavigateTo<MainViewModel>();
        }
    }
}
