using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SousChef.Domain.Interfaces
{
    /// <summary>
    /// Exposes methods for working with recipes in persistent storage
    /// </summary>
    public interface IRecipeRepository
    {
        /// <summary>
        /// Saves the recipe to persistent storage.
        /// </summary>
        /// <param name="recipe">The recipe.</param>
        Task<Result> SaveRecipeAsync(IRecipe recipe);
    }
}
