using System;

namespace SousChef.Dto
{
    public class RecipeIngredientDto
    {
        public Guid Id { get; set; }
        public string Ingredient { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public string RawText { get; set; }
    }
}