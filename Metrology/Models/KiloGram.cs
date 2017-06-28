using System;
using System.Collections.Generic;
using System.Text;

namespace Metrology.Models
{
    public class KiloGram : UnitBase
    {
        public KiloGram()
            :base("kg", "kilogram", Constants.SIBaseUnit.Mass) { }

        public override decimal ConvertFromStandardUnit(decimal standardUnitQuantity)
        {
            throw new NotImplementedException();
        }

        public override decimal ConvertToStandardUnit(decimal quantity)
        {
            throw new NotImplementedException();
        }
    }
}
