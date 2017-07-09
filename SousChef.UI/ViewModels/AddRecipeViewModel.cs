using SousChef.Shell.Interfaces;
using SousChef.Shell.ViewModels;
using SousChef.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using SousChef.Domain.Interfaces;
using SousChef.Domain;

namespace SousChef.UI.ViewModels
{
    public class AddRecipeViewModel : ViewModelBase, IAddRecipeViewModel
    {
        private readonly IRecipeFactory recipeFactory;
        private readonly IRecipeRepository recipeRepository;

        private string name;
        private string instructions;
        private IngredientViewModel selectedIngredient;


        public ObservableCollection<IngredientViewModel> Ingredients
        {
            get;
        } = new ObservableCollection<IngredientViewModel>();

        public string Name
        {
            get => name;
            set {
                Set(ref name, value);
                RequeryCommands();
            }
        }

        public IngredientViewModel SelectedIngredient
        {
            get => selectedIngredient;
            set => Set(ref selectedIngredient, value);
        }

        public string Instructions
        {
            get => instructions;
            set => Set(ref instructions, value);
        }

        public IAsyncRelayCommand<object> SaveRecipeCommand
        {
            get;
        }

        public IRelayCommand AddIngredientCommand
        {
            get;
        }

        public IRelayCommand RemoveIngredientCommand
        {
            get;
        }

        public AddRecipeViewModel(IRelayCommandFactory commandFactory,
                                  IRecipeFactory recipeFactory,
                                  IRecipeRepository recipeRepository)
        {
            if(commandFactory == null)
            {
                throw new ArgumentNullException(nameof(commandFactory));
            }

            SaveRecipeCommand = commandFactory.CreateAsyncCommand<object>(OnSave, CanSave);
            AddIngredientCommand = commandFactory.CreateCommand(OnAddIngredient, CanAddIngredient);
            RemoveIngredientCommand = commandFactory.CreateCommand(OnRemoveIngredient, CanRemoveIngredient);

            for(int i = 0; i < 3; i++)
            {
                this.Ingredients.Add(new IngredientViewModel());
            }

            this.recipeFactory = recipeFactory ?? throw new ArgumentNullException(nameof(recipeFactory));
            this.recipeRepository = recipeRepository ?? throw new ArgumentNullException(nameof(recipeRepository));
        }

        private bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(Name);
        }

        private bool CanAddIngredient()
        {
            return true;
        }

        private bool CanRemoveIngredient()
        {
            return SelectedIngredient != null;
        }

        private void OnAddIngredient()
        {
            if(!CanAddIngredient())
            {
                return;
            }

            Ingredients.Add(new IngredientViewModel());
        }

        private void OnRemoveIngredient()
        {
            if(!CanRemoveIngredient())
            {
                return;
            }

            Ingredients.Remove(SelectedIngredient);
        }

        private async Task<object> OnSave(CancellationToken arg)
        {
            if(!this.CanSave())
            {
                return new object();
            }

            var recipe = recipeFactory.CreateRecipe(Name,
                                                    Ingredients.Select(x => x.Text),
                                                    Instructions);

            var result = await recipeRepository.SaveRecipeAsync(recipe);

            return null;
        }

        private void RequeryCommands()
        {
            this.SaveRecipeCommand.RaiseCanExecuteChanged();
        }
    }
}
