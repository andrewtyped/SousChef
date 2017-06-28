using System;
using System.Collections.Generic;

namespace SousChef.Data.Models
{
    public partial class RecipeInstruction
    {
        public Guid Id { get; set; }
        public Guid RecipeId { get; set; }
        public string Instruction { get; set; }
        public int Sequence { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
