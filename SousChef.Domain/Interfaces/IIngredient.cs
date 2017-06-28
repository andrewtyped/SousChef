using System;
using System.Collections.Generic;
using System.Text;

namespace SousChef.Domain.Interfaces
{
    /// <summary>
    /// Represents a raw ingredient. Tomato, onion, chicken, etc.
    /// </summary>
    public interface IIngredient
    {
        /// <summary>
        /// The ingredient identifier.
        /// </summary>
        Guid Id
        {
            get;
        }

        /// <summary>
        /// The ingredient's name.
        /// </summary>
        string Name
        {
            get;
        }
    }
}
