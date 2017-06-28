using System;
using System.Collections.Generic;

namespace SousChef.Data.Models
{
    public partial class RecipeIngredient
    {
        public Guid Id { get; set; }
        public Guid RecipeId { get; set; }
        public string Ingredient { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public string RawText { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
