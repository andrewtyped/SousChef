using SousChef.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using CSharpFunctionalExtensions;
using System.Threading.Tasks;

namespace SousChef.Domain.Services
{
    public class RecipeRepository : IRecipeRepository
    {
        public Task<Result> SaveRecipeAsync(IRecipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}
