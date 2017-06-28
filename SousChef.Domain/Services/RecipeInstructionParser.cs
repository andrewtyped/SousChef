using SousChef.Domain.Interfaces;
using SousChef.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SousChef.Domain.Services
{
    public class RecipeInstructionParser : IRecipeInstructionParser
    {
        public (bool, IEnumerable<IInstruction>) TryParse(string instructionText)
        {
            if(string.IsNullOrWhiteSpace(instructionText))
            {
                return (true, Enumerable.Empty<IInstruction>());
            }

            var instructions = instructionText.Split(new[] { Environment.NewLine, "\\r\\r", "\r\r" }, StringSplitOptions.RemoveEmptyEntries);

            var success = true;
            var parsedInstructions = instructions.Select((instruction, i) => new Instruction(Guid.Empty, instruction, i)).ToArray();

            return (success, parsedInstructions);
        }
    }
}
