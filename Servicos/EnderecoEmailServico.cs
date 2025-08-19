using Persistencia;

namespace Servicos;

public class EnderecoEmailServico(Contexto contexto) : IEnderecoEmailServico
{
    public async Task<int> CriarEnderecoEmail(string endereco, CancellationToken cancellationToken)
    {
        var set = contexto.Set<EnderecoEmail>();
        var enderecoArmazenado = new EnderecoEmail { Endereco = endereco, Ativo = false };
        await set.AddAsync(enderecoArmazenado);
        await contexto.SaveChangesAsync(cancellationToken);
        return enderecoArmazenado.Id;
    }
}
