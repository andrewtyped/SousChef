using System;
using System.Collections.Generic;
using System.Text;

namespace Metrology.Models
{
    public class Pound : UnitBase
    {
        public Pound()
            : base("lb", "pound", Constants.SIBaseUnit.Mass) { }

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
