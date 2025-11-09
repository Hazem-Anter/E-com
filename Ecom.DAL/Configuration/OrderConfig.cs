
namespace Ecom.DAL.Configuration
{
    internal class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.Status)
                .HasConversion<string>(); // Stores enum as string

            builder.Property(o => o.TotalAmount)
               .HasColumnType("decimal(18,2)");
        }
    }
}
