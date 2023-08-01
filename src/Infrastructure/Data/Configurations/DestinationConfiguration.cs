namespace Infrastructure.Data;

public class DestinationConfiguration : IEntityTypeConfiguration<Destination>
{
    public void Configure(EntityTypeBuilder<Destination> builder)
    {
        builder.Property(d => d.Price)
            .HasPrecision(10, 2);
    }
}