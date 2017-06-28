using Metrology.Interfaces;
using Metrology.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SousChef.Domain.Constants
{
    public static class UnitDictionary
    {
        public static HashSet<string> CaseSensitiveUnits = new HashSet<string>()
        {
            "t" //Tablespoon (T) or teaspoon (t)
        };

        public static Dictionary<string, IUnit> Units = new Dictionary<string, IUnit>()
        {
            {"gram", new Gram()},
            {"microgram", new Ounce()},
            {"mcg", new Ounce()},
            {"milligram", new Ounce()},
            {"mg", new Ounce()},
            {"kg", new KiloGram()},
            {"joule", new Ounce()},
            {"kilojoule", new Ounce()},
            {"calorie", new Ounce()},
            {"InternationalUnit", new Ounce()},
            {"IU", new Ounce()},
            {"bag", new Ounce()},
            {"barrel", new Ounce()},
            {"bottle", new Ounce()},
            {"box", new Ounce()},
            {"bunch", new Ounce()},
            {"bushel", new Ounce()},
            {"can", new Ounce()},
            {"case", new Ounce()},
            {"centimeter", new Ounce()},
            {"cm", new Ounce()},
            {"clove", new Ounce()},
            {"cup", new Cup()},
            {"c", new Cup()},
            {"dash", new Ounce()},
            {"drum", new Ounce()},
            {"ear", new Ounce()},
            {"gallon", new Gallon()},
            {"gal", new Gallon()},
            {"g", new Gram()},
            {"handful", new Ounce()},
            {"inch", new Ounce()},
            {"in", new Ounce()},
            {"jar", new Ounce()},
            {"kilogram", new KiloGram()},
            {"kilometer", new Ounce()},
            {"k", new Ounce()},
            {"lb", new Pound()},
            {"liter", new Ounce()},
            {"li", new Ounce()},
            {"meter", new Ounce()},
            {"m", new Ounce()},
            {"mile", new Ounce()},
            {"mi", new Ounce()},
            {"milliliter", new Ounce()},
            {"ml", new Ounce()},
            {"millimeter", new Ounce()},
            {"mm", new Ounce()},
            {"ounce", new Ounce()},
            {"oz", new Ounce()},
            {"package", new Ounce()},
            {"pkg", new Ounce()},
            {"part", new Ounce()},
            {"peck", new Ounce()},
            {"piece", new Indefinite("piece")},
            {"pinch", new Ounce()},
            {"pint", new Pint()},
            {"pt", new Pint()},
            {"pound", new Pound()},
            {"quart", new Quart()},
            {"qt", new Quart()},
            {"shot", new Ounce()},
            {"slice", new Ounce()},
            {"sprig", new Ounce()},
            {"stick", new Ounce()},
            {"splash", new Ounce()},
            {"tablespoon", new Ounce()},
            {"tbsp", new Tablespoon()},
            {"T", new Tablespoon()},
            {"teaspoon", new Teaspoon()},
            {"tsp", new Teaspoon()},
            {"t", new Teaspoon()},
            {"yard", new Ounce()},
            {"yd", new Ounce() }
        };
    }
}
