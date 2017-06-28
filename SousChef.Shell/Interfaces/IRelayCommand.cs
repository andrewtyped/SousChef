using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SousChef.Shell.Interfaces
{
    public interface IRelayCommand : ICommand
    {
        void RaiseCanExecuteChanged();
    }

    public interface IRelayCommand<T> : ICommand
    {
        void RaiseCanExecuteChanged();
    }
}
