namespace Servicos;

public interface IEnderecoEmailServico
{
    public Task<bool> CriarEnderecoEmail(string endereco, CancellationToken cancellationToken);
}
