using Metrology.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrology.Interfaces
{
    public interface IUnit
    {
        string Symbol { get; }

        string Name { get; }

        SIBaseUnit StandardUnit { get; }

        decimal ConvertToStandardUnit(decimal quantity);

        decimal ConvertFromStandardUnit(decimal standardUnitQuantity);
    }
}
