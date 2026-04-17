using DebitosTributarios.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DebitosTributarios.Infrastructure.Context.Configurations
{
    internal sealed class ContribuinteConfiguration : IEntityTypeConfiguration<Contribuinte>
    {
        public void Configure(EntityTypeBuilder<Contribuinte> builder)
        {
            builder.Property(x => x.CpfCnpj).HasMaxLength(14);

            builder.HasIndex(x => x.CpfCnpj).IsUnique();
        }
    }
}
