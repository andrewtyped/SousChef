using SousChef.Shell.Interfaces;
using SousChef.Shell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SousChef.Shell.Services
{
    public class RelayCommandFactory : IRelayCommandFactory
    {
        /// <summary>
        /// Creates a command that runs synchronously, accepts no parameters and can always execute
        /// </summary>
        /// <param name="execute">The function to call when executing the created command.</param>
        /// <returns></returns>
        public IRelayCommand CreateCommand(Action execute)
        {
            return new RelayCommand(execute ?? throw new ArgumentNullException(nameof(execute)));
        }

        /// <summary>
        /// Creates a command that runs synchronously, accepts no parameters and executes depending on the result of the <paramref name="canExecute" /> predicate.
        /// </summary>
        /// <param name="execute">The function to call when executing the created command.</param>
        /// <param name="canExecute">A predicate which determines whether or not the command can be executed.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        /// execute
        /// or
        /// canExecute
        /// </exception>
        public IRelayCommand CreateCommand(Action execute, Func<bool> canExecute)
        {
            return new RelayCommand(execute ?? throw new ArgumentNullException(nameof(execute)),
                                    canExecute ?? throw new ArgumentNullException(nameof(canExecute)));
        }

        /// <summary>
        /// Creates a command that runs synchrously, accepts a parameter, and can always execute.
        /// </summary>
        /// <typeparam name="T">The parameter type passed to the <paramref name="execute" /> delegate.</typeparam>
        /// <param name="execute">The function to call when executing the created command</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">execute</exception>
        public IRelayCommand<T> CreateCommand<T>(Action<T> execute)
        {
            return new RelayCommand<T>(execute ?? throw new ArgumentNullException(nameof(execute)));
        }

        /// <summary>
        /// Creates a command that runs synchronously, accepts a parameter, and executes depending on the result of the <paramref name="canExecute" /> predicate.
        /// </summary>
        /// <typeparam name="T">The parameter type passed to the <paramref name="execute" /> delegate.</typeparam>
        /// <param name="execute">The function to call when executing the created command.</param>
        /// <param name="canExecute">A predicate which determines whether or not the command can be executed.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        /// execute
        /// or
        /// canExecute
        /// </exception>
        public IRelayCommand<T> CreateCommand<T>(Action<T> execute, Func<T, bool> canExecute)
        {
            return new RelayCommand<T>(execute ?? throw new ArgumentNullException(nameof(execute)),
                                       canExecute ?? throw new ArgumentNullException(nameof(canExecute)));
        }

        /// <summary>
        /// Creates a command that runs asynchronously, accepts no parameters and can always execute
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="execute">The function to call when executing the created command.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">execute</exception>
        public IAsyncRelayCommand<TResult> CreateAsyncCommand<TResult>(Func<CancellationToken, Task<TResult>> execute)
        {
            return new AsyncRelayCommand<TResult>(execute ?? throw new ArgumentNullException(nameof(execute)));
        }

        /// <summary>
        /// Creates a command that runs asynchronously, accepts no parameters and executes depending on the result of the <paramref name="canExecute" /> predicate.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="execute">The function to call when executing the created command.</param>
        /// <param name="canExecute">A predicate which determines whether or not the command can be executed.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        /// execute
        /// or
        /// canExecute
        /// </exception>
        public IAsyncRelayCommand<TResult> CreateAsyncCommand<TResult>(Func<CancellationToken, Task<TResult>> execute, Func<bool> canExecute)
        {
            return new AsyncRelayCommand<TResult>(execute ?? throw new ArgumentNullException(nameof(execute)),
                                                  canExecute ?? throw new ArgumentNullException(nameof(canExecute)));
        }

        /// <summary>
        /// Creates a command that runs asynchrously, accepts a parameter, and can always execute.
        /// </summary>
        /// <typeparam name="T">The parameter type passed to the <paramref name="execute" /> delegate.</typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="execute">The function to call when executing the created command.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">execute</exception>
        public IAsyncRelayCommand<T, TResult> CreateAsyncCommand<T, TResult>(Func<T, CancellationToken, Task<TResult>> execute)
        {
            return new AsyncRelayCommand<T, TResult>(execute ?? throw new ArgumentNullException(nameof(execute)));
        }

        /// <summary>
        /// Creates a command that runs synchronously, accepts a parameter, and executes depending on the result of the <paramref name="canExecute" /> predicate.
        /// </summary>
        /// <typeparam name="T">The parameter type passed to the <paramref name="execute" /> delegate.</typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="execute">The function to call when executing the created command.</param>
        /// <param name="canExecute">A predicate which determines whether or not the command can be executed.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        /// execute
        /// or
        /// canExecute
        /// </exception>
        public IAsyncRelayCommand<T, TResult> CreateAsyncCommand<T, TResult>(Func<T, CancellationToken, Task<TResult>> execute, Func<T, bool> canExecute)
        {
            return new AsyncRelayCommand<T, TResult>(execute ?? throw new ArgumentNullException(nameof(execute)),
                                                  canExecute ?? throw new ArgumentNullException(nameof(canExecute)));
        }
    }
}
