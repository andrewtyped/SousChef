using SousChef.Shell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SousChef.Shell.Interfaces
{
    public interface IAsyncRelayCommand<TResult> : IRelayCommand
    {
        ICommand CancelCommand { get; }

        Task ExecuteAsync(object parameter);

        NotifyTaskCompletion<TResult> Execution { get; }
    }

    public interface IAsyncRelayCommand<TParameter, TResult> : IRelayCommand
    {
        ICommand CancelCommand { get; }

        Task ExecuteAsync(TParameter parameter);

        NotifyTaskCompletion<TResult> Execution { get; }
    }
}
