using SousChef.Shell.Controls;
using SousChef.Shell.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SousChef.Shell.Services
{
    public class Navigator : INavigator
    {
        private readonly object locker = new object();
        private readonly IViewResolver viewResolver;

        private static Frame AppFrame => ((Window.Current.Content as Frame)?.Content as MainPage)?.AppFrame;

        public Navigator(IViewResolver viewResolver)
        {
            this.viewResolver = viewResolver ?? throw new ArgumentNullException(nameof(viewResolver));
        }

        /// <summary>
        /// Navigates to a view based on its viewmodel
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        public void NavigateTo<TViewModel>(TViewModel viewModel)
        {
            lock (locker)
            {
                Type viewType;

                try
                {
                    viewType = viewResolver.ResolveViewTypeFromViewModel<TViewModel>();
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"No view is registered for view model [{typeof(TViewModel).FullName}]", ex);
                }

                Debug.Assert(AppFrame != null);
                AppFrame.Navigate(viewType);
                ((FrameworkElement)AppFrame.Content).DataContext = viewModel;
            }
        }
    }
}
