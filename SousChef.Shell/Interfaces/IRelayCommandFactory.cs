using SousChef.Shell.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SousChef.Shell.Interfaces
{
    public interface IRelayCommandFactory
    {
        /// <summary>
        /// Creates a command that runs synchronously, accepts no parameters and can always execute
        /// </summary>
        /// <param name="execute">The function to call when executing the created command.</param>
        /// <returns></returns>
        IRelayCommand CreateCommand(Action execute);

        /// <summary>
        /// Creates a command that runs synchronously, accepts no parameters and executes depending on the result of the <paramref name="canExecute"/> predicate.
        /// </summary>
        /// <param name="execute">The function to call when executing the created command.</param>
        /// <param name="canExecute">A predicate which determines whether or not the command can be executed.</param>
        /// <returns></returns>
        IRelayCommand CreateCommand(Action execute, Func<bool> canExecute);

        /// <summary>
        /// Creates a command that runs synchrously, accepts a parameter, and can always execute.
        /// </summary>
        /// <typeparam name="T">The parameter type passed to the <paramref name="execute"/> delegate.</typeparam>
        /// <param name="execute">The function to call when executing the created command</param>
        /// <returns></returns>
        IRelayCommand<T> CreateCommand<T>(Action<T> execute);

        /// <summary>
        /// Creates a command that runs synchronously, accepts a parameter, and executes depending on the result of the <paramref name="canExecute"/> predicate.
        /// </summary>
        /// <typeparam name="T">The parameter type passed to the <paramref name="execute"/> delegate.</typeparam>
        /// <param name="execute">The function to call when executing the created command.</param>
        /// <param name="canExecute">A predicate which determines whether or not the command can be executed.</param>
        /// <returns></returns>
        IRelayCommand<T> CreateCommand<T>(Action<T> execute, Func<T, bool> canExecute);

        /// <summary>
        /// Creates a command that runs asynchronously, accepts no parameters and can always execute
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="execute">The function to call when executing the created command.</param>
        /// <returns></returns>
        IAsyncRelayCommand<TResult> CreateAsyncCommand<TResult>(Func<CancellationToken, Task<TResult>> execute);

        /// <summary>
        /// Creates a command that runs asynchronously, accepts no parameters and executes depending on the result of the <paramref name="canExecute"/> predicate. 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="execute">The function to call when executing the created command.</param>
        /// <param name="canExecute">A predicate which determines whether or not the command can be executed.</param>
        /// <returns></returns>
        IAsyncRelayCommand<TResult> CreateAsyncCommand<TResult>(Func<CancellationToken, Task<TResult>> execute, Func<bool> canExecute);

        /// <summary>
        ///  Creates a command that runs asynchrously, accepts a parameter, and can always execute.
        /// </summary>
        /// <typeparam name="T">The parameter type passed to the <paramref name="execute"/> delegate.</typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="execute">The function to call when executing the created command.</param>
        /// <returns></returns>
        IAsyncRelayCommand<T, TResult> CreateAsyncCommand<T, TResult>(Func<T, CancellationToken, Task<TResult>> execute);

        /// <summary>
        /// Creates a command that runs synchronously, accepts a parameter, and executes depending on the result of the <paramref name="canExecute"/> predicate. 
        /// </summary>
        /// <typeparam name="T">The parameter type passed to the <paramref name="execute"/> delegate.</typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="execute">The function to call when executing the created command.</param>
        /// <param name="canExecute">A predicate which determines whether or not the command can be executed.</param>
        /// <returns></returns>
        IAsyncRelayCommand<T, TResult> CreateAsyncCommand<T, TResult>(Func<T, CancellationToken, Task<TResult>> execute, Func<T, bool> canExecute);
    }
}
