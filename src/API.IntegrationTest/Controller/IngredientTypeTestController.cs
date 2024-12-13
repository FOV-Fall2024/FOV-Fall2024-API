namespace API.IntegrationTest.Controller;
public class IngredientTypeTestController(DatabaseFixture db) : IClassFixture<DatabaseFixture>
{
    [Fact]
    public async Task CanGetAllEntries()
    {
        throw new Exception();
        //var repository = db.Service.GetRequiredService<IIngredientTypeRepository>();
        //var isender =

        //var result = await IngredientTypeController(repository);

        //Assert.IsAssignableFrom<Ok<IEnumerable<IngredientType>>>(result);

        //var data = ((Ok<IEnumerable<IngredientType>>)result).Value;
        //Assert.NotNull(data);
        //Assert.NotEmpty(data);
    }
}
