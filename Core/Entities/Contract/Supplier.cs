using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Core.Entities.Abstract;

namespace Core.Entities.Contract
{
    public class Supplier : BaseClass
    {
        public Supplier() { }
        public Supplier(string? name)
        {
            Name = name;
        }

        public Supplier(int? id, string name)
        {
            Id = id;
            Name = name;
        }

        [Column("Id")]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Suppliers name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters")]
        public string? Name { get; private set; }

        public ICollection<Contract> Contracts { get;  private set; }
        public ICollection<SupplierDeposit> SupplierDeposits { get; private set; }
        public void Update(string name)
        {
            if(string.IsNullOrEmpty(name)) throw new ArgumentNullException("Supplier name");
            Name = name;
        }
    }
    
}
