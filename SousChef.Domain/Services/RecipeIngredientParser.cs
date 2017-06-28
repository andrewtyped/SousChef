using Metrology.Interfaces;
using Metrology.Models;
using SousChef.Domain.Constants;
using SousChef.Domain.Interfaces;
using SousChef.Domain.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace SousChef.Domain.Services
{
    public class RecipeIngredientParser : IRecipeIngredientParser
    {
        public (bool, IRecipeIngredient) TryParse(string ingredientText)
        {
            if(string.IsNullOrWhiteSpace(ingredientText))
            {
                return (false, null);
            }

            var i = GetQuantityIngredientSeparatorPosition(ingredientText);

            var quantitySubString = i > 0 ? ingredientText.Substring(0, i).Trim() : "0";

            decimal decimalQty = 0.0m;
            if(quantitySubString.Contains("/") || quantitySubString.Contains("\\"))
            {
                decimalQty = this.ParseFraction(quantitySubString);
            }
            else
            {
                decimalQty = decimal.Parse(quantitySubString);
            }

            var ingredientSubString = ingredientText.Substring(i).Trim();

            var (unit, ingredient) = ParseUnit(ingredientSubString);

            return (true, 
                    new RecipeIngredient(Guid.Empty, 
                                         ingredient, 
                                         new Quantity(decimalQty, 
                                                      unit), 
                                         ingredientText));
        }

        private int GetQuantityIngredientSeparatorPosition(string ingredientText)
        {
            int i;
            bool fractionSet = false;
            bool decimalSet = false;

            for (i = 0; i < ingredientText.Length; i++)
            {
                var character = ingredientText[i];
                if (Char.IsLetter(character))
                {
                    break;
                }

                if (Char.IsWhiteSpace(character) || Char.IsDigit(character))
                {
                    continue;
                }

                if (character == Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
                {
                    if (!decimalSet)
                    {
                        //Guard against multiple decimal points
                        decimalSet = true;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                if( character == '/' || character == '\\')
                {
                    if(!fractionSet)
                    {
                        fractionSet = true;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return i;
        }

        private decimal ParseFraction(string quantity)
        {
            var splitCharacter = quantity.Contains("/") ? '/' : '\\';

            var splitQuantity = quantity.Split(splitCharacter);

            var (wholeNumber, numerator) = ParseNumerator(splitQuantity[0]);

            var denominator = decimal.Parse(splitQuantity[1]);

            return Math.Round(wholeNumber + (numerator / denominator), 2);
        }

        private (decimal wholeNumber, decimal numerator) ParseNumerator(string wholeNumberAndNumerator)
        {
            var splitWholeNumberAndNumerator = Tokenize(wholeNumberAndNumerator);

            decimal numerator;
            decimal wholeNumber;

            if (splitWholeNumberAndNumerator.Length > 2)
            {
                //TODO: Log unexpected whole number / numerator split;
                wholeNumber = decimal.Parse(splitWholeNumberAndNumerator[0]);
                numerator = decimal.Parse(splitWholeNumberAndNumerator[1]);
            }
            else if (splitWholeNumberAndNumerator.Length == 2)
            {
                wholeNumber = decimal.Parse(splitWholeNumberAndNumerator[0]);
                numerator = decimal.Parse(splitWholeNumberAndNumerator[1]);
            }
            else if (splitWholeNumberAndNumerator.Length == 1)
            {
                wholeNumber = 0.0m;
                numerator = decimal.Parse(splitWholeNumberAndNumerator[0]);
            }
            else
            {
                numerator = 0.0m;
                wholeNumber = 0.0m;
            }

            return (wholeNumber, numerator);
        }

        private (IUnit unit, string ingredient) ParseUnit(string ingredientSubstring)
        {
            if(string.IsNullOrWhiteSpace(ingredientSubstring))
            {
                return (new Unitless(), ingredientSubstring);
            }

            var units = UnitDictionary.Units;

            var ingredientTokens = Tokenize(ingredientSubstring);

            var possibleUnit = ingredientTokens[0].TrimEnd(new[] { '.' });
            var possibleUnitLength = ingredientTokens[0].Length;

            IUnit unit;
            string ingredient = ingredientSubstring;

            //Check first for case sensitive units like "T"
            if(units.ContainsKey(possibleUnit))
            {
                unit = units[possibleUnit];

                //We found a unit, so the rest of the string is the ingredient
                ingredient = ingredientSubstring.Substring(possibleUnitLength);
            }
            else
            {
                var caseInsensitivePossibleUnit = possibleUnit.ToLower();

                //Check for case-insensitive units.
                if (units.ContainsKey(caseInsensitivePossibleUnit))
                {
                    unit = units[caseInsensitivePossibleUnit];

                    //We found a unit, so the rest of the string is the ingredient
                    ingredient = ingredientSubstring.Substring(possibleUnitLength);
                }
                else
                {
                    unit = new Unitless();
                }
            }

            return (unit, ingredient.Trim());
        }

        private string[] Tokenize(string str)
        {
            //Pass null to use ANY whitespace char as delimiter
            var tokens = str.Split((char[])null,StringSplitOptions.RemoveEmptyEntries);

            for(int i = 0; i < tokens.Length; i++)
            {
                tokens[i] = tokens[i].Trim();
            }

            return tokens;
        }
    }
}
