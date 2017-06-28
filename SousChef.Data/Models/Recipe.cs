using System;
using System.Collections.Generic;

namespace SousChef.Data.Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            RecipeIngredient = new HashSet<RecipeIngredient>();
            RecipeInstruction = new HashSet<RecipeInstruction>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RecipeIngredient> RecipeIngredient { get; set; }
        public virtual ICollection<RecipeInstruction> RecipeInstruction { get; set; }
    }
}
