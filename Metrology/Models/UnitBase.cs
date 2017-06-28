using Metrology.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Metrology.Constants;

namespace Metrology.Models
{
    public abstract class UnitBase : IUnit
    {
        public string Symbol
        {
            get;
        }

        public string Name
        {
            get;
        }

        public SIBaseUnit StandardUnit
        {
            get;
        }

        public IEnumerable<string> Aliases
        {
            get;
        }

        public UnitBase(string symbol,
                        string name,
                        SIBaseUnit siBaseUnit,
                        IEnumerable<string> aliases = null)
        {
            this.Symbol = symbol ?? throw new ArgumentNullException(nameof(symbol));
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.StandardUnit = siBaseUnit ?? throw new ArgumentNullException(nameof(siBaseUnit));
            this.Aliases = aliases ?? new List<string>();
        }

        public abstract decimal ConvertFromStandardUnit(decimal standardUnitQuantity);

        public abstract decimal ConvertToStandardUnit(decimal quantity);

        public override string ToString()
        {
            return this.Name;
        }
    }
}
