using System;
using System.Collections.Generic;
using System.Text;

namespace Metrology.Models
{
    public class Indefinite : UnitBase
    {
        public Indefinite(string name)
            :base("",name, Constants.SIBaseUnit.None)
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
