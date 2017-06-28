using Metrology.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SousChef.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SousChef.Domain.Tests.Services
{
    [TestClass]
    public class RecipeIngredientParserTests
    {
        private readonly RecipeIngredientParser parser = new RecipeIngredientParser();

        [TestMethod]
        public void Does_Not_Parse_Null_Or_Whitespace()
        {
            string rawText = null;

            var (success, ingredient) = parser.TryParse(rawText);

            Assert.IsFalse(success);
            Assert.IsNull(ingredient);
        }

        [TestMethod]
        public void Parses_SimpleIngredient()
        {
            var rawText = "Salt";
            var (success, recipeIngredient) = parser.TryParse(rawText);

            Assert.IsTrue(success);
            Assert.AreEqual(rawText, recipeIngredient.RawText);
            Assert.AreEqual(rawText, recipeIngredient.Ingredient);
        }

        [TestMethod]
        public void Parses_Ingredient_With_Instruction()
        {
            var rawText = "Onions, chopped";

            var (success, recipeIngredient) = parser.TryParse(rawText);

            Assert.IsTrue(success);
            Assert.AreEqual(rawText, recipeIngredient.RawText);
            Assert.AreEqual("Onions, chopped", recipeIngredient.Ingredient);
        }

        [TestMethod] 
        public void Parses_Ingredient_With_Quantity()
        {
            var rawText = "1 egg";
            var (success, recipeIngredient) = parser.TryParse(rawText);

            Assert.IsTrue(success);
            Assert.AreEqual(rawText, recipeIngredient.RawText);
            Assert.AreEqual("egg", recipeIngredient.Ingredient);
            Assert.AreEqual(new Quantity(1.0m, new Unitless()), recipeIngredient.Quantity);
        }

        [TestMethod]
        public void Parses_Ingredient_With_Decimal_Quantity()
        {
            var rawText = "1.5 egg";
            var (success, recipeIngredient) = parser.TryParse(rawText);

            Assert.IsTrue(success);
            Assert.AreEqual(rawText, recipeIngredient.RawText);
            Assert.AreEqual("egg", recipeIngredient.Ingredient);
            Assert.AreEqual(new Quantity(1.5m, new Unitless()), recipeIngredient.Quantity);
        }

        [TestMethod]
        public void Parses_Ingredient_With_Bad_Decimal_Quantity()
        {
            var rawText = "1.5 . egg";
            var (success, recipeIngredient) = parser.TryParse(rawText);

            Assert.IsTrue(success);
            Assert.AreEqual(rawText, recipeIngredient.RawText);
            Assert.AreEqual(". egg", recipeIngredient.Ingredient);
            Assert.AreEqual(new Quantity(1.5m, new Unitless()), recipeIngredient.Quantity);
        }

        [TestMethod]
        public void Parses_Ingredient_With_Fractional_Quantity()
        {
            var rawText = "1/2 egg";
            var (success, recipeIngredient) = parser.TryParse(rawText);

            Assert.IsTrue(success);
            Assert.AreEqual(rawText, recipeIngredient.RawText);
            Assert.AreEqual("egg", recipeIngredient.Ingredient);
            Assert.AreEqual(new Quantity(0.5m, new Unitless()), recipeIngredient.Quantity);
        }

        [TestMethod]
        public void Parses_Ingredient_With_Mixed_Fractional_Quantity()
        {
            var rawText = "3 1/2 egg";
            var (success, recipeIngredient) = parser.TryParse(rawText);

            Assert.IsTrue(success);
            Assert.AreEqual(rawText, recipeIngredient.RawText);
            Assert.AreEqual("egg", recipeIngredient.Ingredient);
            Assert.AreEqual(new Quantity(3.5m, new Unitless()), recipeIngredient.Quantity);
        }

        [TestMethod]
        public void Parses_Ingredient_With_Bad_Fractional_Quantity()
        {
            var rawText = "3/1/2 egg";
            var (success, recipeIngredient) = parser.TryParse(rawText);

            Assert.IsTrue(success);
            Assert.AreEqual(rawText, recipeIngredient.RawText);
            Assert.AreEqual("/2 egg", recipeIngredient.Ingredient);
            Assert.AreEqual(new Quantity(3.0m, new Unitless()), recipeIngredient.Quantity);
        }

        [TestMethod]
        public void Parses_Ingredient_With_Cups_Unit()
        {
            var rawText = "1 1/4 c. olive oil";
            var (success, recipeIngredient) = parser.TryParse(rawText);

            Assert.IsTrue(success);
            Assert.AreEqual(rawText, recipeIngredient.RawText);
            Assert.AreEqual("olive oil", recipeIngredient.Ingredient);
            Assert.AreEqual(new Quantity(1.25m, new Cup()), recipeIngredient.Quantity);
        }

        [TestMethod]
        public void Parses_Ingredient_With_Tablespoon_Unit()
        {
            var rawText = "2 1/3 T olive oil";
            var (success, recipeIngredient) = parser.TryParse(rawText);

            Assert.IsTrue(success);
            Assert.AreEqual(rawText, recipeIngredient.RawText);
            Assert.AreEqual("olive oil", recipeIngredient.Ingredient);
            Assert.AreEqual(new Quantity(2.33m, new Tablespoon()), recipeIngredient.Quantity);
        }

        [TestMethod]
        public void Parses_Ingredient_With_Alternate_Tablespoon_Unit()
        {
            var rawText = "2 1/3 tbsp olive oil";
            var (success, recipeIngredient) = parser.TryParse(rawText);

            Assert.IsTrue(success);
            Assert.AreEqual(rawText, recipeIngredient.RawText);
            Assert.AreEqual("olive oil", recipeIngredient.Ingredient);
            Assert.AreEqual(new Quantity(2.33m, new Tablespoon()), recipeIngredient.Quantity);
        }

        [TestMethod]
        public void Parses_Ingredient_With_Teaspoon_Unit()
        {
            var rawText = "2 1/3 t olive oil";
            var (success, recipeIngredient) = parser.TryParse(rawText);

            Assert.IsTrue(success);
            Assert.AreEqual(rawText, recipeIngredient.RawText);
            Assert.AreEqual("olive oil", recipeIngredient.Ingredient);
            Assert.AreEqual(new Quantity(2.33m, new Teaspoon()), recipeIngredient.Quantity);
        }


        [TestMethod]
        public void Parses_Ingredient_With_Weird_Spacing()
        {
            var rawText = $"2 {Environment.NewLine}  1  /   3  t olive oil";
            var (success, recipeIngredient) = parser.TryParse(rawText);

            Assert.IsTrue(success);
            Assert.AreEqual(rawText, recipeIngredient.RawText);
            Assert.AreEqual("olive oil", recipeIngredient.Ingredient);
            Assert.AreEqual(new Quantity(2.33m, new Teaspoon()), recipeIngredient.Quantity);
        }
    }
}
