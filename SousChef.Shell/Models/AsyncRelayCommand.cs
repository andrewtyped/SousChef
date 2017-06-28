using SousChef.Shell.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SousChef.Shell.Models
{
    public class AsyncRelayCommand<TResult> : NotifyPropertyChangedBase,  IAsyncRelayCommand<TResult>
    {
        protected static Func<bool> returnTrue = () => true;

        protected Func<CancellationToken, Task<TResult>> execute;

        protected Func<bool> canExecute;

        private NotifyTaskCompletion<TResult> exeuction;

        private readonly CancelAsyncCommand cancelCommand = new CancelAsyncCommand();

        public AsyncRelayCommand(Func<CancellationToken, Task<TResult>> executeMethod)
            :this(executeMethod, returnTrue)
        {

        }

        public AsyncRelayCommand(Func<CancellationToken, Task<TResult>> executeMethod, Func<bool> canExecuteMethod)
        {
            this.execute = executeMethod ?? throw new ArgumentNullException(nameof(executeMethod));
            this.canExecute = canExecuteMethod ?? throw new ArgumentNullException(nameof(canExecuteMethod));
        }

        public ICommand CancelCommand => cancelCommand;

        public NotifyTaskCompletion<TResult> Execution
        {
            get => this.exeuction;
            private set => Set(ref exeuction, value);
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return (Execution == null || Execution.IsCompleted) && canExecute();
        }

        public async void Execute(object parameter)
        {
            await this.execute(cancelCommand.Token);
        }

        public async Task ExecuteAsync(object parameter)
        {
            cancelCommand.NotifyCommandStarting();
            Execution = new NotifyTaskCompletion<TResult>(execute(cancelCommand.Token));
            RaiseCanExecuteChanged();
            await Execution.TaskCompletion;
            cancelCommand.NotifyCommandFinished();
            RaiseCanExecuteChanged();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

       
    }

    public class AsyncRelayCommand<TParameter, TResult> : NotifyPropertyChangedBase, IAsyncRelayCommand<TParameter, TResult>
    {
        protected static Func<TParameter, bool> returnTrue = (TParameter parameter) => true;

        protected Func<TParameter, CancellationToken, Task<TResult>> execute;

        protected Func<TParameter, bool> canExecute;

        private NotifyTaskCompletion<TResult> exeuction;

        private readonly CancelAsyncCommand cancelCommand = new CancelAsyncCommand();

        public AsyncRelayCommand(Func<TParameter, CancellationToken, Task<TResult>> executeMethod)
            : this(executeMethod, returnTrue)
        {

        }

        public AsyncRelayCommand(Func<TParameter, CancellationToken, Task<TResult>> executeMethod, Func<TParameter, bool> canExecuteMethod)
        {
            this.execute = executeMethod ?? throw new ArgumentNullException(nameof(executeMethod));
            this.canExecute = canExecuteMethod ?? throw new ArgumentNullException(nameof(canExecuteMethod));
        }

        public ICommand CancelCommand => cancelCommand;

        public NotifyTaskCompletion<TResult> Execution
        {
            get => this.exeuction;
            private set => Set(ref exeuction, value);
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return (Execution == null || Execution.IsCompleted) && canExecute((TParameter)parameter);
        }

        public async void Execute(object parameter)
        {
            await this.execute((TParameter)parameter, cancelCommand.Token);
        }

        public async Task ExecuteAsync(TParameter parameter)
        {
            cancelCommand.NotifyCommandStarting();
            Execution = new NotifyTaskCompletion<TResult>(execute(parameter, cancelCommand.Token));
            RaiseCanExecuteChanged();
            await Execution.TaskCompletion;
            cancelCommand.NotifyCommandFinished();
            RaiseCanExecuteChanged();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    internal sealed class CancelAsyncCommand : ICommand
    {
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private bool commandExecuting;

        public CancellationToken Token => cancellationTokenSource.Token;

        public event EventHandler CanExecuteChanged;

        public void NotifyCommandStarting()
        {
            commandExecuting = true;

            if (!cancellationTokenSource.IsCancellationRequested)
            {
                return;
            }

            cancellationTokenSource = new CancellationTokenSource();
            RaiseCanExecuteChanged();
        }

        public void NotifyCommandFinished()
        {
            commandExecuting = false;
            RaiseCanExecuteChanged();
        }

        public bool CanExecute(object parameter)
        {
            return commandExecuting && !cancellationTokenSource.IsCancellationRequested;
        }

        public void Execute(object parameter)
        {
            cancellationTokenSource.Cancel();
            RaiseCanExecuteChanged();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
