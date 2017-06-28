using SousChef.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SousChef.UI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddRecipeView : Page
    {
        private bool isShiftKeyDown;

        public AddRecipeView()
        {
            this.InitializeComponent();
        }

        private void IngredientsListBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if(e.Key == VirtualKey.Shift)
            {
                isShiftKeyDown = false;
            }

        }

        private void IngredientsListBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if(e.Key == VirtualKey.Shift)
            {
                isShiftKeyDown = true;
            }
            else if(isShiftKeyDown)
            {
                var viewModel = this.DataContext as IAddRecipeViewModel;

                Debug.Assert(viewModel != null);

                viewModel.AddIngredientCommand.Execute(null);
                e.Handled = true;
            }
        }
    }
}
