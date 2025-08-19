using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Persistencia;
using Testcontainers.MsSql;
using Servicos;
using Microsoft.EntityFrameworkCore;

namespace TestesIntegracao;

public class EnderecoEmailServicoSpec : WebApplicationFactory<Program>, IClassFixture<SqlServerFixture>
{
    private readonly IServiceProvider _serviceProvider;
    private readonly Contexto _contexto;
    private readonly MsSqlContainer _testContainer = null!;

    public EnderecoEmailServicoSpec(SqlServerFixture fixture)
    {
        Environment.SetEnvironmentVariable("SQLCONNSTR_Default", fixture.TestContainer.GetConnectionString());
        _serviceProvider = Services.CreateScope().ServiceProvider;
        _contexto = ObterDependencia<Contexto>();
        _contexto.Database.Migrate();
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

    [Fact(Skip = "Usei só pra me certificar que conseguia migrar a partir do código")]
    public void ConsegueMigrarBanco()
    {
        var contexto = ObterDependencia<Contexto>();
        contexto.Database.Migrate();
    }

    // NOTE: state-based
    [Fact]
    public async Task CriaUmEnderecoEmailValido()
    {
        // arrange
        var sut = ObterDependencia<IEnderecoEmailServico>();

        // act
        await sut.CriarEnderecoEmail("jonhdoe1996@gmail.com", CancellationToken.None);

        // assert
        var endereco = await _contexto.EnderecoEmail.FirstOrDefaultAsync(x =>
            x.Endereco == "jonhdoe1996@gmail.com"
        );

        Assert.Multiple(() =>
        {
            Assert.NotNull(endereco);
            Assert.False(endereco.Ativo);
        });
    }
}
