using System;
using System.Collections.Generic;
using System.Text;

namespace Metrology.Models
{
    public class Tablespoon : UnitBase
    {
        public Tablespoon()
            :base("tbsp","tablespoon", Constants.SIBaseUnit.Volume) { }

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
