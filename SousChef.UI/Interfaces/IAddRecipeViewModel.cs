using SousChef.Shell.Interfaces;
using SousChef.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SousChef.UI.Interfaces
{
    public interface IAddRecipeViewModel : IViewModelBase
    {
        string Name { get; }

        ObservableCollection<IngredientViewModel> Ingredients { get; }

        IngredientViewModel SelectedIngredient { get; }

        string Instructions { get; }

        IRelayCommand AddIngredientCommand { get; }

        IRelayCommand RemoveIngredientCommand { get; }
    }
}
