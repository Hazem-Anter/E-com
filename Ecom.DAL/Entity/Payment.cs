
namespace Ecom.DAL.Entity
{
    public class Payment
    {
        [Key]
        public int Id { get; private set; }
        public PaymentMethod? PaymentMethod { get; private set; } // Enum: Cash, Card, Paypal
        public PaymentStatus Status { get; private set; } // Enum: Pending, Completed, Failed
        public decimal TotalAmount { get; private set; }
        public string? TransactionId { get; private set; } // From gateway
        public string? CreatedBy { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime? UpdatedOn { get; private set; }
        public string? UpdatedBy { get; private set; }
        public bool IsDeleted { get; private set; }

        // Foriegn Keys
        [ForeignKey("Order")]
        public int? OrderId { get; private set; }

        // Navigation Properties
        public virtual Order? Order { get; private set; }

        // Logic
        public Payment() { }
        public Payment(int orderId, decimal totalamount, PaymentMethod paymentMethod, string? transactionId,
            string createdBy)
        {
            OrderId = orderId;
            TotalAmount = totalamount;
            PaymentMethod = paymentMethod;
            Status = PaymentStatus.Pending;
            TransactionId = transactionId;
            CreatedBy = createdBy;
            CreatedOn = DateTime.UtcNow;
            IsDeleted = false;
        }

        public bool Update(int orderId, decimal totalamount, PaymentMethod paymentMethod, string? transactionId,
            string userModified, PaymentStatus paymentStatus)
        {
            if (!string.IsNullOrEmpty(userModified))
            {
                Status = paymentStatus;
                PaymentMethod = paymentMethod;
                UpdatedBy = userModified;
                UpdatedOn = DateTime.UtcNow;
                TransactionId = transactionId;
                OrderId = orderId;
                TotalAmount = totalamount;
                return true;
            }
            return false;
        }

        public bool ToggleDelete(string userModified)
        {
            if (!string.IsNullOrEmpty(userModified))
            {
                IsDeleted = !IsDeleted;
                UpdatedBy = userModified;
                UpdatedOn = DateTime.UtcNow;
                return true;
            }
            return false;
        }

    }
}
