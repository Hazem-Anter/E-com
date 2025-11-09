
namespace Ecom.DAL.Configuration
{
    public class CartItemConfig : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartId);

            builder.Property(ci => ci.UnitPrice)
                .HasColumnType("decimal(18,2)");

        }
    }
}
