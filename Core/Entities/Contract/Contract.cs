using Core.Entities.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Contract
{
    public class Contract
    {
        public Contract(int id, string? legalEntityName, int? customerId, int? contactId, int? applicationUserId, DateTime? soldDate, BillingChargeType billingChargeType, BillingType billingType, EnrollmentType enrollmentType, PricingType pricingType)
        {
            Id = id;
            LegalEntityName = legalEntityName;
            CustomerId = customerId;
            ContactId = contactId;
            ApplicationUserId = applicationUserId;
            SoldDate = soldDate;
            BillingChargeType = billingChargeType;
            BillingType = billingType;
            EnrollmentType = enrollmentType;
            PricingType = pricingType;
        }
        public Contract(string? legalEntityName, int? customerId, int? contactId, int? applicationUserId, DateTime? soldDate, BillingChargeType billingChargeType, BillingType billingType, EnrollmentType enrollmentType, PricingType pricingType)
        {
            LegalEntityName = legalEntityName;
            CustomerId = customerId;
            ContactId = contactId;
            ApplicationUserId = applicationUserId;
            SoldDate = soldDate;
            BillingChargeType = billingChargeType;
            BillingType = billingType;
            EnrollmentType = enrollmentType;
            PricingType = pricingType;
        }
        public Contract() { }

        [Column("Id")]
        public int Id { get; init; }
        public string? LegalEntityName { get; set; }
        //FK Customer
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        //FK Contact
        public int? ContactId { get; set; }
        public Contact? Contact { get; set; }

        //FK ApplicationUser
        public int? ApplicationUserId { get; set; }
        public ApplicationUsers? ApplicationUser { get; set; }

        public ICollection<ContractItem>? ContractItems { get; set; }

        public DateTime? SoldDate { get; set; }
        public BillingChargeType BillingChargeType { get; set; }
        public BillingType BillingType { get; set; }
        public EnrollmentType EnrollmentType { get; set; }
        public PricingType PricingType { get; set; }
    }
}
