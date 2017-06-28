using SousChef.Shell.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SousChef.Shell.Models
{
    public class RelayCommand : IRelayCommand
    {
        protected static Func<bool> returnTrue = () => true;

        protected Action execute;

        protected Func<bool> canExecute;

        public RelayCommand(Action executeMethod)
            :this(executeMethod, returnTrue)
        {

        }

        public RelayCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            this.execute = executeMethod ?? throw new ArgumentNullException(nameof(executeMethod));
            this.canExecute = canExecuteMethod ?? throw new ArgumentNullException(nameof(canExecuteMethod));
        }

        public event EventHandler CanExecuteChanged; 

        public bool CanExecute(object parameter)
        {
            return this.canExecute();
        }

        public virtual void Execute(object parameter)
        {
            this.execute();
        }

        public void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public class RelayCommand<T> : IRelayCommand<T>
    {
        private static Func<T, bool> returnTrue = (T param) => true;

        private Action<T> execute;

        private Func<T, bool> canExecute;

        public RelayCommand(Action<T> executeMethod)
            : this(executeMethod, returnTrue)
        {

        }

        public RelayCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            this.execute = executeMethod ?? throw new ArgumentNullException(nameof(executeMethod));
            this.canExecute = canExecuteMethod ?? throw new ArgumentNullException(nameof(canExecuteMethod));
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return this.canExecute((T)parameter);
        }

        public virtual void Execute(object parameter)
        {
            this.execute((T)parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
