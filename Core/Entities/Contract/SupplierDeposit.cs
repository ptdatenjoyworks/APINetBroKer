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
        //FK Suppliers
        [ForeignKey(nameof(Suppliers))]
        public int? SupplierId { get; set; }
        public Supplier? Suppliers { get; set; }

        public DateTime? PaymentDate { get; set; }
        public decimal? Amount { get; set; }
    }
}
