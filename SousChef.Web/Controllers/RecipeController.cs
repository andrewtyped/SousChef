using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SousChef.Dto;
using SousChef.Data.Models;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SousChef.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class RecipeController : Controller
    {
        private readonly SousChefDbContext context;
        private readonly ILogger<RecipeController> logger;

        public RecipeController(SousChefDbContext context,
                                ILogger<RecipeController> logger)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // POST api/values
        [HttpPost("save", Name = "Save_Recipe")]
        public async Task<IActionResult> SaveRecipe([FromBody]RecipeDto recipeDto)
        {
            logger.LogTrace("Entering SaveRecipe");

            if (recipeDto == null)
            {
                return BadRequest("Empty recipe.");
            }

            try
            {
                var recipe = new Recipe
                {
                    Name = recipeDto.Name
                };

                var ingredients = recipeDto.RecipeIngredients.Select(ingredient => new RecipeIngredient()
                {
                    Recipe = recipe,
                    Ingredient = ingredient.Ingredient,
                    Quantity = ingredient.Quantity,
                    Unit = ingredient.Unit,
                    RawText = ingredient.RawText
                }).ToList();

                var instructions = recipeDto.RecipeInstructions.Select(instruction => new RecipeInstruction
                {
                    Recipe = recipe,
                    Instruction = instruction.Instruction,
                    Sequence = instruction.Sequence
                });

                await context.RecipeIngredient.AddRangeAsync(ingredients);
                await context.RecipeInstruction.AddRangeAsync(instructions);

                await context.SaveChangesAsync();

                logger.LogInformation("Recipe saved successfully");
                return Ok();
            }
            catch(Exception ex)
            {
                logger.LogError(ex.ToString());
                return BadRequest("An error occurred while saving the recipe.");
            }
        }
    }
}
