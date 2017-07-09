using System;

namespace SousChef.Dto
{
    public class RecipeInstructionDto
    {
        public Guid Id { get; set; }
        public string Instruction { get; set; }
        public int Sequence { get; set; }
    }
}