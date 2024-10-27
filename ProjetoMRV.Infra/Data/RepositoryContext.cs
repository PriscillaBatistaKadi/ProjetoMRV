using Microsoft.EntityFrameworkCore;
using ProjetoMRV.Domain.Entities;

namespace ProjetoMRV.Infra.Data
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }

        public DbSet<SpaEntity> Spa { get; set; }
    }
}
