using System;
using System.Collections.Generic;
using System.Text;
using Metrology.Constants;

namespace Metrology.Models
{
    public class FluidOunce : UnitBase
    {
        public FluidOunce() : base("fl oz", "fluid ounce", Constants.SIBaseUnit.Volume, new List<string>() { "oz fl" })
        {
        }

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
