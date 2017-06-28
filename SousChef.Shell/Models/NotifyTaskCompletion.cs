using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SousChef.Shell.Models
{
    public sealed class NotifyTaskCompletion<TResult> : NotifyPropertyChangedBase
    {
        public NotifyTaskCompletion(Task<TResult> task)
        {
            this.Task = task ?? throw new ArgumentNullException(nameof(task));

            if(!task.IsCompleted)
            {
                TaskCompletion = WatchTaskAsync(task);
            }
        }

        public Task<TResult> Task
        {
            get;
        }

        public Task TaskCompletion
        {
            get;
        }

        public TResult Result => Task.Status == TaskStatus.RanToCompletion ? Task.Result : default(TResult);

        public TaskStatus Status => Task.Status;

        public bool IsCompleted => Task.IsCompleted;

        public bool IsNotCompleted => !this.IsCompleted;

        public bool IsSuccessfullyCompleted => Task.Status == TaskStatus.RanToCompletion;

        public bool IsCanceled => Task.IsCanceled;

        public bool IsFaulted => Task.IsFaulted;

        public AggregateException Exception => Task.Exception;

        public Exception InnerException => Task.Exception?.InnerException;

        public string ErrorMessage => InnerException?.Message;

        private async Task WatchTaskAsync(Task task)
        {
            try
            {
                await task;
            }
            catch
            {
                //do nothing, caller will need to check status / exceptions.
            }

            if(!PropertyChangedHasSubscriptions)
            {
                return;
            }

            Set(nameof(Status));
            Set(nameof(IsCompleted));
            Set(nameof(IsNotCompleted));
            
            if(task.IsCanceled)
            {
                Set(nameof(IsCanceled));
            }
            else if(task.IsFaulted)
            {
                Set(nameof(IsFaulted));
                Set(nameof(Exception));
                Set(nameof(InnerException));
                Set(nameof(ErrorMessage));
            }
            else
            {
                Set(nameof(IsSuccessfullyCompleted));
                Set(nameof(Result));
            }


        }
        
    }
}
