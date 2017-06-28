using System;
using System.Collections.Generic;
using System.Text;
using Metrology.Interfaces;

namespace SousChef.Domain.Interfaces
{
    /// <summary>
    /// Represents an ingredient, along with its amount, used in a recipe
    /// </summary>
    public interface IRecipeIngredient
    {
        /// <summary>
        /// The recipe ingredient's id
        /// </summary>
        Guid Id
        {
            get;
        }

        /// <summary>
        /// The type of ingredient used in the recipe
        /// </summary>
        string Ingredient { get; }

        /// <summary>
        /// The quantity of the ingredient used in the recipe
        /// </summary>
        IQuantity Quantity { get; }

        /// <summary>
        /// Preperatory instructions for the ingredient. Chopped, minced, blanched, etc.
        /// </summary>
        string Instruction { get; }

        /// <summary>
        /// Gets a value indicating whether or not the ingredient is optional in the recipe
        /// </summary>
        bool IsOptional { get; }

        /// <summary>
        /// Gets the raw text of the ingredient as entered by the user.
        /// </summary>
        /// <value>
        /// The raw text.
        /// </value>
        string RawText { get; }
    }
}
