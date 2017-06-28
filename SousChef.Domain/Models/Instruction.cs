using System;
using System.Collections.Generic;
using System.Text;

namespace SousChef.Domain.Models
{
    /// <summary>
    /// Represents an instruction used in a recipe's preperation
    /// </summary>
    public class Instruction : Interfaces.IInstruction
    {
        /// <summary>
        /// The instruction identifier.
        /// </summary>
        public Guid Id
        {
            get;
        }

        /// <summary>
        /// The text of the instruction
        /// </summary>
        public string Text
        {
            get;
        }

        /// <summary>
        /// The sequence in which the instruction appears in the recipe
        /// </summary>
        public int Sequence
        {
            get;
        }

        public Instruction(Guid id, 
                           string text,
                           int sequence)
        {
            this.Id = id;
            this.Text = text ?? throw new ArgumentNullException(nameof(text));
            this.Sequence = sequence;
        }
    }
}
