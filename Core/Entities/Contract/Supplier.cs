using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Core.Models.Requests.Contract;
using Core.Entities.Enum;
using Core.Entities.Abstract;

namespace Core.Entities.Contract
{
    public class Supplier : BaseClass
    {
        public Supplier(string? name)
        {
            Name = name;
        }

        [Column("Id")]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Suppliers name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters")]
        public string? Name { get; set; }

        public ICollection<Contract> Contracts { get; set; }
        public ICollection<SupplierDeposit> SupplierDeposits { get; set; }
        public void Update(string name,bool isActive, Stage stage)
        {
            if(string.IsNullOrEmpty(name)) throw new ArgumentNullException("Supplier name");
            Name = name;
            IsActive = isActive;
            Stage = stage;
        }
    }
    
}
