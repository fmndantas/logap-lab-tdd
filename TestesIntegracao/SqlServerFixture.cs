using Testcontainers.MsSql;

namespace TestesIntegracao;

public class SqlServerFixture : IAsyncLifetime
{
    public readonly MsSqlContainer TestContainer = new MsSqlBuilder().Build();

    public Task InitializeAsync()
    {
        return TestContainer.StartAsync();
    }

    public Task DisposeAsync()
    {
        return TestContainer.DisposeAsync().AsTask();
    }
}
