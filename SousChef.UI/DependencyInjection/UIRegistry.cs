using SousChef.UI.Interfaces;
using SousChef.UI.ViewModels;
using StructureMap;
using StructureMap.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SousChef.UI.DependencyInjection
{
    public class UIRegistry : Registry
    {
        public UIRegistry()
        {
            For<IMainViewModel>().Use<MainViewModel>().LifecycleIs<SingletonLifecycle>();
            For<IAddRecipeViewModel>().Use<AddRecipeViewModel>().LifecycleIs<SingletonLifecycle>();
            For<IMyRecipesViewModel>().Use<MyRecipesViewModel>().LifecycleIs<SingletonLifecycle>();
        }
    }
}
