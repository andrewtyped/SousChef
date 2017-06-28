using System;
using System.Collections.Generic;
using System.Text;

namespace Metrology.Models
{
    public class Pint : UnitBase
    {
        public Pint()
            : base("pt", "pint", Constants.SIBaseUnit.Volume) { }

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
