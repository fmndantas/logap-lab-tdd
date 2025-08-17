using Microsoft.EntityFrameworkCore;

namespace Persistencia;

public class Contexto(DbContextOptions<Contexto> opcoes) : DbContext(opcoes)
{
    public virtual DbSet<EnderecoEmail> EnderecoEmail { get; private set; } = null!;
}
