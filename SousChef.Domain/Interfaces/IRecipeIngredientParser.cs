using System;
using System.Collections.Generic;
using System.Text;

namespace SousChef.Domain.Interfaces
{
    public interface IRecipeIngredientParser
    {
        (bool, IRecipeIngredient) TryParse(string ingredientText);
    }
}
