using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SousChef.Shell.Models
{
    public class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool PropertyChangedHasSubscriptions => PropertyChanged != null;

        protected void Set<T>(ref T property, T value, [CallerMemberName]string propertyName = "")
        {
            if (object.ReferenceEquals(property, value))
            {
                return;
            }

            if (property?.Equals(value) ?? false)
            {
                return;
            }

            property = value;
            this.OnPropertyChanged(propertyName);
        }

        protected void Set([CallerMemberName]string propertyName = "")
        {
            this.OnPropertyChanged(propertyName);
        }

        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
