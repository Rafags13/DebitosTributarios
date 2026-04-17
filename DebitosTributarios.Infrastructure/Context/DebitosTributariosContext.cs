using DebitosTributarios.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DebitosTributarios.Infrastructure.Context
{
    public class DebitosTributariosContext(DbContextOptions<DebitosTributariosContext> options) : DbContext(options)
    {
        public DbSet<Contribuinte> Contribuintes { get; set; }
        public DbSet<Debito> Debitos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DebitosTributariosContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntidadeBase>()
                .Where(q => q.State is EntityState.Added))
            {
                if (entry.State == EntityState.Added)
                    entry.Entity.DataCriacao = DateTime.UtcNow;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
