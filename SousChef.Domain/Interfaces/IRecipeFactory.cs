using System;
using System.Collections.Generic;
using System.Text;

namespace SousChef.Domain.Interfaces
{
    public interface IRecipeFactory
    {
        IRecipe CreateRecipe(string name,
                             IEnumerable<string> ingredients,
                             string instructions);
    }
}
