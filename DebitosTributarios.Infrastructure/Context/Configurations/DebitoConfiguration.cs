using DebitosTributarios.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DebitosTributarios.Infrastructure.Context.Configurations
{
    internal sealed class DocumentoConfiguration : IEntityTypeConfiguration<Debito>
    {
        public void Configure(EntityTypeBuilder<Debito> builder)
        {

        }
    }
}
