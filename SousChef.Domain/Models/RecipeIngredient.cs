using SousChef.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Metrology.Interfaces;

namespace SousChef.Domain.Models
{
    public class RecipeIngredient : IRecipeIngredient
    {
        /// <summary>
        /// The recipe ingredient's id
        /// </summary>
        public Guid Id
        {
            get;
        }

        /// <summary>
        /// The type of ingredient used in the recipe
        /// </summary>
        public string Ingredient { get; }

        /// <summary>
        /// The quantity of the ingredient used in the recipe
        /// </summary>
        public IQuantity Quantity { get; }

        /// <summary>
        /// Preperatory instructions for the ingredient. Chopped, minced, blanched, etc.
        /// </summary>
        public string Instruction { get; }

        /// <summary>
        /// Gets the raw text of the ingredient as entered by the user.
        /// </summary>
        /// <value>
        /// The raw text.
        /// </value>
        public string RawText { get; }

        /// <summary>
        /// Gets a value indicating whether or not the ingredient is optional in the recipe
        /// </summary>
        public bool IsOptional { get; }

        public RecipeIngredient(Guid id,
                                string ingredient,
                                IQuantity quantity,
                                string rawText,
                                string instruction = "",
                                bool isOptional = false)
        {
            this.Id = id;
            this.Ingredient = ingredient ?? throw new ArgumentNullException(nameof(ingredient));
            this.Quantity = quantity ?? throw new ArgumentNullException(nameof(quantity));
            this.Instruction = instruction ?? throw new ArgumentNullException(nameof(instruction));
            this.IsOptional = isOptional;
            this.RawText = rawText ?? throw new ArgumentNullException(nameof(instruction));
        }
    }
}
