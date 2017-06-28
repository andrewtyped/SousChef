using System;
using System.Collections.Generic;
using System.Text;
using SousChef.Domain.Interfaces;

namespace SousChef.Domain.Models
{
    /// <summary>
    /// Represents a raw ingredient. Onion, Tomato, etc.
    /// </summary>
    public class Ingredient : IIngredient
    {
        /// <summary>
        /// The ingredient identifier
        /// </summary>
        public Guid Id
        {
            get;
        }

        /// <summary>
        /// The ingredient name
        /// </summary>
        public string Name
        {
            get;
        }

        public Ingredient(Guid id,
                          string name)
        {
            this.Id = id;
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
