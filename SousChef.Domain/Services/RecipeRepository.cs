using SousChef.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using CSharpFunctionalExtensions;
using System.Threading.Tasks;
using SousChef.Security.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace SousChef.Domain.Services
{
    public class RecipeRepository : IRecipeRepository
    {
        
        private static HttpClient client = new HttpClient(new HttpClientHandler() { ClientCertificateOptions = ClientCertificateOption.Automatic });
        private readonly ICurrentUserProvider currentUserProvider;
        private readonly IRecipeDtoFactory recipeDtoFactory;

        public RecipeRepository(ICurrentUserProvider currentUserProvider,
                                IRecipeDtoFactory recipeDtoFactory)
        {
            this.currentUserProvider = currentUserProvider ?? throw new ArgumentNullException(nameof(currentUserProvider));
            this.recipeDtoFactory = recipeDtoFactory ?? throw new ArgumentNullException(nameof(recipeDtoFactory));

            client.BaseAddress = new Uri("https://souschefweb.azurewebsites.net/");
            //client.BaseAddress = new Uri("https://localhost:44361/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Result> SaveRecipeAsync(IRecipe recipe)
        {
            recipe = recipe ?? throw new ArgumentNullException(nameof(recipe));

            var recipeDto = recipeDtoFactory.CreateRecipeDto(recipe);

            var json = JsonConvert.SerializeObject(recipeDto);
            var message = new HttpRequestMessage(HttpMethod.Post, "api/recipe/save");
            message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", currentUserProvider.CurrentUser.AccessToken);
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.SendAsync(message);

            if (response.IsSuccessStatusCode)
            {
                return Result.Ok();
            }
            else
            {
                return Result.Fail("error");
            }
        }  
    }
}
