using Core.Entities.Enum;
using Core.Entities.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Contract
{
    public class Contract
    {
   
      
        public Contract() { }

        public Contract(string? legalEntityName, int? customerId,  int? contactId,  int? closerId,  int? fronterId,  int suppliersId, 
            DateTime? soldDate, BillingChargeType billingChargeType, BillingType billingType, EnrollmentType enrollmentType, PricingType pricingType)
        {
            LegalEntityName = legalEntityName;
            CustomerId = customerId;
            ContactId = contactId;
            CloserId = closerId;
            FronterId = fronterId;
            SupplierId = suppliersId;
            SoldDate = soldDate;
            BillingChargeType = billingChargeType;
            BillingType = billingType;
            EnrollmentType = enrollmentType;
            PricingType = pricingType;
        }

        [Column("Id")]
        public int Id { get; init; }
        public string? LegalEntityName { get; set; }
        //FK Customer
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        //FK Contact
        public int? ContactId { get; set; }
        public Contact? Contact { get; set; }
        public int? CloserId { get; private set; }
        public ApplicationUser? Closer { get; set; }
        public int? FronterId { get; private set; }
        public ApplicationUser? Fronter { get; set; }
        public int SupplierId { get; set; }  
        public Supplier? Supplier { get; set; } 
        public ICollection<ContractItem>? ContractItems { get; set; }

        public DateTime? SoldDate { get; set; }
        public BillingChargeType BillingChargeType { get; set; }
        public BillingType BillingType { get; set; }
        public EnrollmentType EnrollmentType { get; set; }
        public PricingType PricingType { get; set; }
    }
}
