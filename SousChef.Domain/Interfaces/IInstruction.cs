using System;
using System.Collections.Generic;
using System.Text;

namespace SousChef.Domain.Interfaces
{
    /// <summary>
    /// Represents a preperatory step in a recipe
    /// </summary>
    public interface IInstruction
    {
        /// <summary>
        /// The instruction identifier.
        /// </summary>
        Guid Id
        {
            get;
        }

        /// <summary>
        /// The text of the instruction
        /// </summary>
        string Text
        {
            get;
        }

        /// <summary>
        /// The sequence in which the instruction appears in the recipe
        /// </summary>
        int Sequence
        {
            get;
        }
    }
}
