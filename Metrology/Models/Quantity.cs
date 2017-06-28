using Metrology.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrology.Models
{
    public class Quantity : IQuantity
    {
        public decimal Amount
        {
            get;
        }

        public IUnit Unit
        {
            get;
        }

        public Quantity(decimal amount, 
                        IUnit unit)
        {
            this.Amount = amount;
            this.Unit = unit ?? throw new ArgumentNullException(nameof(unit));
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as IQuantity);
        }

        public bool Equals(IQuantity other)
        {
            if(other == null)
            {
                return false;
            }

            if(object.ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Amount == other.Amount && this.Unit.Name == other.Unit.Name;
        }

        public override string ToString()
        {
            return $"{Amount} {Unit}".Trim();
        }

        //TODO: Implement Equals for IUnit
        //TODO: Implement GetHashCode
    }
}
