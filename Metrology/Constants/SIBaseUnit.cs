using System;
using System.Collections.Generic;
using System.Text;

namespace Metrology.Constants
{
    /// <summary>
    /// Contains the definitions of the standard international base units.
    /// </summary>
    public abstract class SIBaseUnit : IEquatable<SIBaseUnit>
    {
        /// <summary>
        /// Constructs a new instance of <see cref="SIBaseUnit"/>
        /// </summary>
        /// <param name="symbol">The unit's symbol</param>
        /// <param name="name">The unit's name</param>
        /// <param name="measure">The unit's measure, or dimension (length, mass, time, etc.)</param>
        /// <exception cref="System.ArgumentNullException">symbol or name or measure.</exception>
        public SIBaseUnit(string symbol, 
                          string name,
                          string measure)
        {
            this.Symbol = symbol ?? throw new ArgumentNullException(nameof(symbol));
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <summary>
        /// Gets the unit's symbol
        /// </summary>
        public string Symbol
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the unit's name
        /// </summary>
        public string Name
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the unit's measure (length, mass, time, etc.)
        /// </summary>
        public string Measure
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the SI base unit of length
        /// </summary>
        public static SIBaseUnit Length => new _Meter();

        /// <summary>
        /// Gets an "empty" SI Base unit. Useful for simple counting or unit-less calculations.
        /// </summary>
        public static SIBaseUnit None => new _Null();

        /// <summary>
        /// Gets the SI base unit of mass
        /// </summary>
        public static SIBaseUnit Mass => new _Kilogram();

        /// <summary>
        /// Gets the SI base unit of time
        /// </summary>
        public static SIBaseUnit Time => new _Second();

        /// <summary>
        /// Gets the SI base unit of temperature
        /// </summary>
        public static SIBaseUnit Temperature => new _Kelvin();

        /// <summary>
        /// Gets the SI base unit of volume
        /// </summary>
        public static SIBaseUnit Volume => new _CubicMeter();

        public override bool Equals(object obj)
        {
            var siBaseUnit = obj as SIBaseUnit;

            if(siBaseUnit == null)
            {
                return false;
            }

            return this.Equals(siBaseUnit);
        }

        public bool Equals(SIBaseUnit siBaseUnit)
        {
            if(siBaseUnit == null)
            {
                return false;
            }

            if(object.ReferenceEquals(this, siBaseUnit))
            {
                return true;
            }

            return this.Symbol == siBaseUnit.Symbol
                && this.Name == siBaseUnit.Name
                && this.Measure == siBaseUnit.Measure;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int prime1 = 7283;
                int prime2 = 5449;
                int hash = prime1;
                hash = hash * prime2 + this.Symbol.GetHashCode();
                hash = hash * prime2 + this.Name.GetHashCode();
                hash = hash * prime2 + this.Measure.GetHashCode();
                return hash;
            }
        }

        private class _Null : SIBaseUnit
        {
            public _Null()
                : base("", "None", "") { }
        }

        private class _Meter : SIBaseUnit
        {
            public _Meter()
                : base("m", "metre", "length") { }
        }

        private class _Kilogram : SIBaseUnit
        {
            public _Kilogram()
                : base("kg","kilogram","mass") { }
        }

        private class _Second : SIBaseUnit
        {
            public _Second()
                : base("s", "second", "time") { }
        }

        private class _Kelvin : SIBaseUnit
        {
            public _Kelvin()
                : base("k", "second", "time") { }
        }

        private class _CubicMeter : SIBaseUnit
        {
            public _CubicMeter()
                : base("m3","cubic meter", "volume") { }
        }
    }
}
