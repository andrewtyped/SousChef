using System;
using System.Collections.Generic;
using System.Text;

namespace SousChef.Dto
{    
    public class RecipeDto
    {
        public RecipeDto()
        {
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public RecipeIngredientDto[] RecipeIngredients { get; set; }
        public RecipeInstructionDto[] RecipeInstructions { get; set; }
    }
}
