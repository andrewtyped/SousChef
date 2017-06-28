using System;
using System.Collections.Generic;
using System.Text;

namespace SousChef.Domain.Interfaces
{
    public interface IRecipeInstructionParser
    {
        (bool, IEnumerable<IInstruction>) TryParse(string instructionText);
    }
}
