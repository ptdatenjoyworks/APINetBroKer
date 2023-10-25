using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Contract
{
    public class SupplierDeposit
    {
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
