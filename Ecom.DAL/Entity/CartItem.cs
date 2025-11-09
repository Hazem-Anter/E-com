
namespace Ecom.DAL.Entity
{
    public class CartItem
    {
        [Key]
        public int Id { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal TotalPrice { get; private set; }
        public string? CreatedBy { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime? DeletedOn { get; private set; }
        public string? DeletedBy { get; private set; }
        public DateTime? UpdatedOn { get; private set; }
        public string? UpdatedBy { get; private set; }
        public bool IsDeleted { get; private set; }

        // Foreign Keys
        [ForeignKey("Cart")]
        public int CartId { get; private set; }

        [ForeignKey("Product")]
        public int ProductId { get; private set; }

        // Navigation Properties
        public virtual Cart? Cart { get; private set; }
        public virtual Product? Product { get; private set; }

        // Logic
        public CartItem() { }

        public CartItem(int productId, int cartId, int quantity, decimal unitPrice, string createdBy)
        {
            ProductId = productId;
            CartId = cartId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            CreatedOn = DateTime.UtcNow;
            CreatedBy = createdBy;
            IsDeleted = false;
            TotalPrice = UnitPrice * Quantity;
        }

        public bool Update(int productId, int cartId, int quantity, decimal unitPrice, string userModified)
        {
            if (!string.IsNullOrEmpty(userModified))
            {
                ProductId = productId;
                CartId = cartId;
                Quantity = quantity;
                UnitPrice = unitPrice;
                UpdatedOn = DateTime.UtcNow;
                UpdatedBy = userModified;
                TotalPrice = UnitPrice * Quantity;
                return true;
            }
            return false;
        }
        public bool ToggleDelete(string userModified)
        {
            if (!string.IsNullOrEmpty(userModified))
            {
                IsDeleted = !IsDeleted;
                DeletedOn = DateTime.UtcNow;
                DeletedBy = userModified;
                return true;
            }
            return false;
        }
    }
}
