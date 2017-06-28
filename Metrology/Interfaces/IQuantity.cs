using System;
using System.Collections.Generic;
using System.Text;

namespace Metrology.Interfaces
{
    /// <summary>
    /// Represents a quantity expressed as some unit.
    /// </summary>
    public interface IQuantity : IEquatable<IQuantity>
    {
        /// <summary>
        /// The amount of material in the quantity.
        /// </summary>
        decimal Amount { get; }

        /// <summary>
        /// The unit in which the quantity is expressed.
        /// </summary>
        IUnit Unit { get; }
    }
}
