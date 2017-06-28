using SousChef.Shell.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SousChef.UI.ViewModels
{
    public class IngredientViewModel : ViewModelBase
    {
        private string text;

        public string Text
        {
            get => text;
            set => Set(ref text, value);
        }
    }
}
