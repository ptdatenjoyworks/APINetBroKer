using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Contract
{
    public class Supplier
    {
        [Column("Id")]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Suppliers name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters")]
        public string? Name { get; set; }

        public ICollection<Contract> Contracts { get; set; }
        public ICollection<SupplierDeposit> SupplierDeposits { get; set; }
    }
    
}
