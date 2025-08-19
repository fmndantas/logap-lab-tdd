using Persistencia;
using Servicos;
using Api.Inputs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var stringConexao = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<Contexto>(opcoes =>
{
    opcoes.UseSqlServer(stringConexao, b => b.MigrationsAssembly("Api"));
    opcoes.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddScoped<IEnderecoEmailServico, EnderecoEmailServico>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("enderecos", (Contexto contexto, CancellationToken cancellationToken) =>
{
    var set = contexto.Set<EnderecoEmail>();
    return set.ToListAsync(cancellationToken);
});

app.MapPost("enderecos", async (IEnderecoEmailServico enderecoEmailServico, CriacaoEmail input, CancellationToken cancellationToken) =>
{
    var idEnderecoEmail = await enderecoEmailServico.CriarEnderecoEmail(input.Endereco, cancellationToken);
    return Results.Created("enderecos", new { IdEnderecoEmail = idEnderecoEmail });
});

app.Run();

// NOTE: tornar o Program partial é necessário para conseguir expor adequadamente ao TestesIntegracao
public partial class Program
{
}
