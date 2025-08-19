namespace Servicos;

public interface IEnderecoEmailServico
{
    public Task<int> CriarEnderecoEmail(string endereco, CancellationToken cancellationToken);
}
