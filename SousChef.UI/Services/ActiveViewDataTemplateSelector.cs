using SousChef.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SousChef.UI.Services
{
    public class ActiveViewDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate AddRecipeTemplate { get; set; }
        public DataTemplate MyRecipesTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            if(item == null)
            {
                return null;
            }

            switch(item)
            {
                case IAddRecipeViewModel addRecipeViewModel:
                    return AddRecipeTemplate;
                case IMyRecipesViewModel myRecipesViewModel:
                    return MyRecipesTemplate;
                default:
                    throw new InvalidOperationException($"Unrecognized view model type {item.GetType()}");
            }

        }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            return this.SelectTemplateCore(item);
        }
    }
}
