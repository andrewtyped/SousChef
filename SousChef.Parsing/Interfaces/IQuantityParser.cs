using Metrology.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SousChef.Parsing.Interfaces
{
    public interface IQuantityParser
    {
        bool TryParse(string quantity, out IQuantity parsedQuantity);
    }
}
