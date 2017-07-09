using SousChef.Domain.Interfaces;
using SousChef.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SousChef.Domain.Services
{
    public class RecipeDtoFactory : IRecipeDtoFactory
    {
        public RecipeDto CreateRecipeDto(IRecipe recipe)
        {
            recipe = recipe ?? throw new ArgumentNullException(nameof(recipe));

            var ingredients = recipe.Ingredients.Select(ingredient => new RecipeIngredientDto
            {
                Id = ingredient.Id,
                Ingredient = ingredient.Ingredient,
                Quantity = ingredient.Quantity.Amount,
                Unit = ingredient.Quantity.Unit.Name,
                RawText = ingredient.RawText
            }).ToArray();

            var instructions = recipe.Instructions.Select(instruction => new RecipeInstructionDto
            {
                Id = instruction.Id,
                Instruction = instruction.Text,
                Sequence = instruction.Sequence
            }).ToArray();

            return new RecipeDto
            {
                Id = recipe.Id,
                Name = recipe.Name,
                RecipeIngredients = ingredients,
                RecipeInstructions = instructions
            };
        }
    }
}
