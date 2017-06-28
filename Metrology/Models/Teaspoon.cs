using Metrology.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrology.Models
{
    public class Teaspoon : UnitBase
    {
        public Teaspoon()
            : base("tsp","teaspoon", SIBaseUnit.Volume) { }

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
