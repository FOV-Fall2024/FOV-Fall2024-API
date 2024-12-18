using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Infrastructure.Data;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace API.IntegrationTest;
public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebApplicationFactory>
{
    private readonly IServiceScope _scope;
    public readonly ISender Sender;
    public readonly HttpClient Client;
    public readonly FOVContext DbContext;

    protected BaseIntegrationTest(IntegrationTestWebApplicationFactory factory)
    {
        _scope = factory.Services.CreateScope();
        Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
        Client = factory.CreateClient();
        DbContext = _scope.ServiceProvider.GetRequiredService<FOVContext>();
    }
}
