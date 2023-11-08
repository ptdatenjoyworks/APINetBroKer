using Core.Entities.Abstract;
using Core.Entities.Enum;
using Core.Entities.User;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Contract
{
    public class Contract : BaseClass
    {
   
      
        public Contract() { }

        public Contract(string? legalEntityName,bool isActive, int? customerId,  int? contactId,  int? closerId,  int? fronterId,  int suppliersId, 
            DateTime? soldDate, BillingChargeType billingChargeType, BillingType billingType, EnrollmentType enrollmentType, PricingType pricingType, Stage stage)
        {
            LegalEntityName = legalEntityName;
            IsActive = isActive;
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
            Stage = stage;
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
        public Stage Stage { get; set; } = Stage.Opportunity;

        public void Update(string? legalEntityName, Stage stage, int? customerId, int suppliersId)
        {
            if (!IsActive)
            {
                throw new InvalidEnumArgumentException("Contract not IsActive");
            }
            else if(stage != Stage.Opportunity && SupplierId != suppliersId)
            {
                throw  new InvalidEnumArgumentException("Stage khong phai Opportunity");
            }
            else
            {
                LegalEntityName = legalEntityName;
                CustomerId = customerId;
                SupplierId = suppliersId;
            }
        }
        public void Delete()
        {
            IsActive = false;
        }
    }
}
