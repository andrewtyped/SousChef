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
            For<IRecipeIngredientParser>().Use<RecipeIngredientParser>();
            For<IRecipeInstructionParser>().Use<RecipeInstructionParser>();
            For<IRecipeFactory>().Use<RecipeFactory>();
        }
    }
}
