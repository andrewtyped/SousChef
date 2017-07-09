using SousChef.Domain.Models;
using SousChef.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SousChef.Domain.Interfaces
{
    public interface IRecipeDtoFactory
    {
        RecipeDto CreateRecipeDto(IRecipe recipe);
    }
}
