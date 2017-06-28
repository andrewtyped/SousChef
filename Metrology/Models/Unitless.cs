using System;
using System.Collections.Generic;
using System.Text;

namespace Metrology.Models
{
    /// <summary>
    /// Represents a unit for a quantity without a unit, i.e., a real number.
    /// </summary>
    /// <seealso cref="Metrology.Models.UnitBase" />
    public class Unitless : UnitBase
    {
        public Unitless()
            : base("", "", Constants.SIBaseUnit.None)
        {

        }

        public override decimal ConvertFromStandardUnit(decimal standardUnitQuantity)
        {
            return standardUnitQuantity;
        }

        public override decimal ConvertToStandardUnit(decimal quantity)
        {
            return quantity;
        }
    }
}
