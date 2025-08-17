using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Persistencia;
using Testcontainers.MsSql;
using Servicos;

namespace TestesIntegracao;

public class EnderecoEmailServicoSpec : WebApplicationFactory<Program>, IClassFixture<SqlServerFixture>
{
    private readonly IServiceProvider _serviceProvider;
    private readonly MsSqlContainer _testContainer = null!;

    public EnderecoEmailServicoSpec(SqlServerFixture fixture)
    {
        Environment.SetEnvironmentVariable("SQLCONNSTR_Default", fixture.TestContainer.GetConnectionString());
        _serviceProvider = Services.CreateScope().ServiceProvider;
    }

    private T ObterDependencia<T>()
    {
        return _serviceProvider.GetService<T>()!;
    }

    [Fact]
    public void ConsegueConectarAoTestContainer()
    {
        var contexto = ObterDependencia<Contexto>();
        Assert.True(contexto.Database.CanConnect());
    }

    [Fact]
    public async Task CriaUmEnderecoEmailValido()
    {
        var sut = ObterDependencia<IEnderecoEmailServico>();
        throw new NotImplementedException("TODO");
    }
}
