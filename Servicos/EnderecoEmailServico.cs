using Persistencia;

namespace Servicos;

public class EnderecoEmailServico(Contexto contexto) : IEnderecoEmailServico
{
    public async Task<bool> CriarEnderecoEmail(string endereco, CancellationToken cancellationToken)
    {
        var set = contexto.Set<EnderecoEmail>();
        await set.AddAsync(new EnderecoEmail { Endereco = endereco, Ativo = false });
        await contexto.SaveChangesAsync(cancellationToken);
        return true;
    }
}
