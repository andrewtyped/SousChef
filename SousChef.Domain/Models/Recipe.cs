using SousChef.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SousChef.Domain.Models
{
    public class Recipe : IRecipe
    {
        private readonly List<IRecipeIngredient> ingredients;
        private readonly List<IInstruction> instructions;

        /// <summary>
        /// The recipe Id
        /// </summary>
        public Guid Id
        {
            get;
        }

        /// <summary>
        /// The name of the recipe
        /// </summary>
        public string Name
        {
            get;
        }

        /// <summary>
        /// The ingredients used in the recipe
        /// </summary>
        public IEnumerable<IRecipeIngredient> Ingredients => this.ingredients;

        /// <summary>
        /// The instructions for preparing the recipe.
        /// </summary>
        public IEnumerable<IInstruction> Instructions => this.instructions;

        public Recipe(Guid id,
                      string name,
                      IEnumerable<IRecipeIngredient> ingredients = null,
                      IEnumerable<IInstruction> instructions = null)
        {
            this.Name = name ?? name;
            this.ingredients = ingredients?.ToList() ?? new List<IRecipeIngredient>();
            this.instructions = instructions?.ToList() ?? new List<IInstruction>();
        }
    }
}
