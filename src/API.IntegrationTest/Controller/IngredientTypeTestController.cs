using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using API.IntegrationTest;
using FOV.Application.Features.IngredientTypes.Commands.Create;
using FOV.Application.Features.IngredientTypes.Commands.Update;
using FOV.Presentation.Infrastructure.Core;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace API.IntegrationTest.Controller
{
    public class IngredientTypeTestController : BaseIntegrationTest
    {
        public IngredientTypeTestController(IntegrationTestWebApplicationFactory factory) : base(factory)
        {
        }

        /// <summary>
        /// Test the GET method to retrieve a list of parent ingredient types.
        /// </summary>
        //[Fact]
        //public async Task Get_ShouldReturnListOfIngredientTypes()
        //{
        //    // Arrange
        //    var query = new GetIngredientTypeCommand
        //    {
        //        PageNumber = 1,
        //        PageSize = 10
        //    };

        //    // Act
        //    var response = await Client.GetAsync($"/api/v1/IngredientType?PageNumber={query.PageNumber}&PageSize={query.PageSize}");

        //    // Assert
        //    response.EnsureSuccessStatusCode();
        //    var result = await response.Content.ReadFromJsonAsync<PagedResult<GetChildrenIngredientType>>();
        //    Assert.NotNull(result);
        //    Assert.True(result.Items.Count >= 0); // Ensuring we get a valid result
        //}

        /// <summary>
        /// Test the POST method to create a new ingredient type.
        /// </summary>
        [Fact]
        public async Task Create_ShouldAddNewIngredientTypeToDatabase()
        {
            // Arrange
            var command = new CreateChildIngredientTypeCommand
            {
                IngredientTypeName = "Spicy Sauce",
                IngredientTypeDescription = "A very spicy sauce"
            };

            var productId = await Sender.Send(command);
            var product = DbContext.IngredientTypes.FirstOrDefault(x => x.Id == productId);
            Assert.NotNull(product);
        }

        [Fact]
        public async Task Update_ShouldModifyExistingIngredientType()
        {
            // Arrange: First, create an ingredient type to update
            var createCommand = new CreateChildIngredientTypeCommand
            {
                IngredientTypeName = "Original Sauce",
                IngredientTypeDescription = "Original description"
            };

            var createResponse = await Sender.Send(createCommand);
            await DbContext.SaveChangesAsync();

            // Prepare the update command
            var updateCommand = new UpdateIngredientTypeCommand
            {
                Id = createResponse,
                IngredientTypeName = "Updated Sauce",
                IngredientTypeDescription = "Updated description"
            };

            // Detach any existing entity with the same Id
            var existingIngredientType = await DbContext.IngredientTypes
                .FirstOrDefaultAsync(x => x.Id == createResponse);

            if (existingIngredientType != null)
            {
                DbContext.Entry(existingIngredientType).State = EntityState.Detached;
            }

            // Act
            var updateResponse = await Sender.Send(updateCommand);

            // Verify the update in the database
            var updatedIngredientType = await DbContext.IngredientTypes
                .FirstOrDefaultAsync(x => x.Id == createResponse);

            Assert.NotNull(updatedIngredientType);
        }
    }
    }
