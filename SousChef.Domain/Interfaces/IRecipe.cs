using System;
using System.Collections.Generic;
using System.Text;

namespace SousChef.Domain.Interfaces
{
    /// <summary>
    /// Represents a culinary recipe
    /// </summary>
    public interface IRecipe
    {
        /// <summary>
        /// The recipe Id
        /// </summary>
        Guid Id
        {
            get;
        }

        /// <summary>
        /// The name of the recipe
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// The ingredients used in the recipe
        /// </summary>
        IEnumerable<IRecipeIngredient> Ingredients
        {
            get;
        }

        /// <summary>
        /// The instructions for preparing the recipe.
        /// </summary>
        IEnumerable<IInstruction> Instructions
        {
            get;
        }
    }
}
