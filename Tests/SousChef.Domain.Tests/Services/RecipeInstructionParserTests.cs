using Microsoft.VisualStudio.TestTools.UnitTesting;
using SousChef.Domain.Interfaces;
using SousChef.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SousChef.Domain.Tests.Services
{
    [TestClass]
    public class RecipeInstructionParserTests
    {
        private readonly IRecipeInstructionParser parser = new RecipeInstructionParser();

        [TestMethod]
        public void Parses_RecipeInstructions_Separated_By_NewLines()
        {
            var instructions =
                @"1. Boil water

2. Cook eggs.";

            var (success, parsedInstructions) = parser.TryParse(instructions);

            Assert.IsTrue(success);

            var parsedInstructionsList = parsedInstructions.ToList();

            Assert.AreEqual("1. Boil water", parsedInstructionsList[0].Text);
            Assert.AreEqual("2. Cook eggs.", parsedInstructionsList[1].Text);
        }

        [TestMethod]
        public void Parses_RecipeInstructions_Separated_By_Carriage_Returns()
        {
            var instructions =
                @"1. Boil water\r\r2. Cook eggs.\r\r";

            var (success, parsedInstructions) = parser.TryParse(instructions);

            Assert.IsTrue(success);

            var parsedInstructionsList = parsedInstructions.ToList();

            Assert.AreEqual("1. Boil water", parsedInstructionsList[0].Text);
            Assert.AreEqual("2. Cook eggs.", parsedInstructionsList[1].Text);
        }

        [TestMethod]
        public void Does_Not_Parse_Empty_Instruction_Set()
        {
            var instructions = new List<string>() { "", " ", null };

            foreach(var instruction in instructions)
            {
                var (success, parsedInstructions) = parser.TryParse(instruction);
                Assert.IsTrue(success);
                Assert.AreEqual(0, parsedInstructions.Count());
            }
        }
    }
}
