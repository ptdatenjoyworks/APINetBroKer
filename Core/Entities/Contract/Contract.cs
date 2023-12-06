using Core.Entities.Abstract;
using Core.Entities.Enum;
using Core.Entities.User;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Contract
{
    public class Contract : BaseClass, IIDEntity
    {
   
      
        public Contract() { }

        public Contract(string? legalEntityName, int? customerId,  int? contactId,  int? closerId,  int? fronterId,  int suppliersId, 
            DateTime? soldDate, BillingChargeType billingChargeType, BillingType billingType, EnrollmentType enrollmentType, PricingType pricingType, Stage stage)
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
            Stage = stage;
        }

        [Column("Id")]
        public int Id { get; init; }
        public string? LegalEntityName { get; private set; }
        //FK Customer
        public int? CustomerId { get; private set; }
        public Customer? Customer { get; private set; }
        //FK Contact
        public int? ContactId { get; private set; }
        public Contact? Contact { get; private set; }
        public int? CloserId { get; private set; }
        public ApplicationUser? Closer { get; private set; }
        public int? FronterId { get; private set; }
        public ApplicationUser? Fronter { get; private set; }
        public int? SupplierId { get; private set; }  
        public Supplier? Supplier { get; private set; } 
        public ICollection<ContractItem>? ContractItems { get; private set; }

        public DateTime? SoldDate { get; private set; }
        public DateTime? StartDate { get; private set; }
        public BillingChargeType BillingChargeType { get; set; }
        public BillingType BillingType { get; private set; }
        public EnrollmentType EnrollmentType { get; private set; }
        public PricingType PricingType { get; private set; }
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
