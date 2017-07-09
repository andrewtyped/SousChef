using SousChef.Domain.Interfaces;
using SousChef.Domain.Services;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace SousChef.Domain.DependencyInjection
{
    public class DomainRegistry : Registry
    {
        public DomainRegistry()
        {
            For<IRecipeDtoFactory>().Use<RecipeDtoFactory>().Singleton();
            For<IRecipeIngredientParser>().Use<RecipeIngredientParser>();
            For<IRecipeInstructionParser>().Use<RecipeInstructionParser>();
            For<IRecipeFactory>().Use<RecipeFactory>();
            For<IRecipeRepository>().Use<RecipeRepository>().Singleton();
        }
    }
}
