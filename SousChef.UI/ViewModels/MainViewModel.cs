using SousChef.Shell.Interfaces;
using SousChef.Shell.ViewModels;
using SousChef.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SousChef.UI.ViewModels
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        private readonly INavigator navigator;
        private readonly IRelayCommandFactory relayCommandFactory;

        private IViewModelBase activeView;
        private readonly IAddRecipeViewModel addRecipeViewModel;
        private readonly IMyRecipesViewModel myRecipesViewModel;

        public MainViewModel(INavigator navigator,
                             IRelayCommandFactory relayCommandFactory,
                             IAddRecipeViewModel addRecipeViewModel,
                             IMyRecipesViewModel myRecipesViewModel)
        {
            this.navigator = navigator ?? throw new ArgumentNullException(nameof(navigator));
            this.relayCommandFactory = relayCommandFactory ?? throw new ArgumentNullException(nameof(relayCommandFactory));
            this.addRecipeViewModel = addRecipeViewModel ?? throw new ArgumentNullException(nameof(addRecipeViewModel));
            this.myRecipesViewModel = myRecipesViewModel ?? throw new ArgumentNullException(nameof(addRecipeViewModel));

            this.GoToAddRecipeCommand = relayCommandFactory.CreateCommand(OnGoToAddRecipe);
            this.GoToMyRecipesCommand = relayCommandFactory.CreateCommand(OnGoToMyRecipes);
        }

        public IViewModelBase ActiveView
        {
            get => activeView;
            set => Set(ref activeView, value);
        }

        public IRelayCommand GoToMyRecipesCommand
        {
            get;
        }

        public IRelayCommand GoToAddRecipeCommand
        {
            get;
        }

        private void OnGoToMyRecipes()
        {
            ActiveView = myRecipesViewModel;
        }

        private void OnGoToAddRecipe()
        {
            ActiveView = addRecipeViewModel;
        }
    }
}
