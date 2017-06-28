using System;
using System.Collections.Generic;
using System.Text;
using static Metrology.Constants.SIBaseUnit;

namespace Metrology.Models
{
    public class Cup : UnitBase
    {
        public Cup()
            :base("c","cup", Volume)
        { }

        public override decimal ConvertToStandardUnit(decimal quantity)
        {
            throw new NotImplementedException();
        }

        public override decimal ConvertFromStandardUnit(decimal standardUnitQuantity)
        {
            throw new NotImplementedException();
        }
    }
}
