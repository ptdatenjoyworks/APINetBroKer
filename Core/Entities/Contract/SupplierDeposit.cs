using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Contract
{
    public class SupplierDeposit
    {
        public SupplierDeposit(int? supplierId, DateTime? paymentDate, decimal? amount)
        {
            SupplierId = supplierId;
            PaymentDate = paymentDate;
            Amount = amount;
        }

        [Column("Id")]
        public int? Id { get; set; }
        public int? SupplierId { get; private set; }
        public Supplier? Suppliers { get; private set; }

        public DateTime? PaymentDate { get; private set; }
        public decimal? Amount { get; private set; }
    }
}
