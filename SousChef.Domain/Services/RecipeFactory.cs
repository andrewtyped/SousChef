using SousChef.Domain.Interfaces;
using SousChef.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SousChef.Domain.Services
{
    public class RecipeFactory : IRecipeFactory
    {
        private readonly IRecipeIngredientParser ingredientParser;
        private readonly IRecipeInstructionParser instructionParser;

        public RecipeFactory(IRecipeIngredientParser ingredientParser,
                             IRecipeInstructionParser instructionParser)
        {
            this.ingredientParser = ingredientParser ?? throw new ArgumentNullException(nameof(ingredientParser));
            this.instructionParser = instructionParser ?? throw new ArgumentNullException(nameof(instructionParser));
        }

        public IRecipe CreateRecipe(string name, 
                                    IEnumerable<string> ingredients, 
                                    string instructions)
        {
            if(name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if(ingredients == null)
            {
                throw new ArgumentNullException(nameof(ingredients));
            }

            var parsedIngredients = new List<IRecipeIngredient>();

            foreach (var ingredient in ingredients)
            {
                var (ingredientParseSuccess, parsedIngredient) = ingredientParser.TryParse(ingredient);

                if(!ingredientParseSuccess)
                {
                    throw new InvalidOperationException($"Ingredient [{ingredient}] could not be parsed.");
                }

                parsedIngredients.Add(parsedIngredient);
            }

            var (instructionParseSuccess, parsedInstructions) = instructionParser.TryParse(instructions);

            if(!instructionParseSuccess)
            {
                throw new InvalidOperationException($"Instructions [{instructions}] could not be parsed.");
            }

            return new Recipe(Guid.Empty,
                              name,
                              parsedIngredients,
                              parsedInstructions);
        }
    }
}
