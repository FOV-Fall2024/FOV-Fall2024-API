using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.IntegrationTest.Data;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;
using FOV.Infrastructure.Repository.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.PostgreSql;


namespace API.IntegrationTest;
//public class DatabaseFixture : IAsyncLifetime
//{
//    public IServiceProvider Service;
//    private readonly PostgreSqlContainer _container;

//    public DatabaseFixture()
//    {
//        _container = new PostgreSqlBuilder().Build();

//        var coll = new ServiceCollection();
//        coll.AddTransient<IConfiguration>(_ =>
//        {
//            var config = new List<KeyValuePair<string, string?>>
//            {
//                new ("ConnectionString",_container.GetConnectionString())
//            };
//            return new ConfigurationBuilder().AddInMemoryCollection(config).Build();
//        });

//        coll.AddDbContext<FOVContext>();
//        coll.AddTransient<IIngredientTypeRepository, IngredientTypeRepository>();
//        coll.AddTransient<IngredientTypeFaker>();
//        Service = coll.BuildServiceProvider();


//    }

//    public async Task DisposeAsync()
//    {
//        await _container.StopAsync();
//    }

//    public async Task InitializeAsync()
//    {
//        await _container.StartAsync();
//        var context = Service.GetRequiredService<FOVContext>();
//        await context.Database.EnsureCreatedAsync();
//    }

//}
