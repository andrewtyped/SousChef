using System;
using System.Collections.Generic;
using System.Text;

namespace SousChef.Shell.Interfaces
{
    public interface INavigator
    {
        void NavigateTo<T>(T viewmodel);
    }
}
