using Core.Entities.Abstract;

namespace Core.Models.Response.Contracts
{
    public class ContractReponse : BaseClass
    {

        public int Id { get; init; }
        public string? LegalEntityName { get; set; }
        public int? CloserId { get; private set; }
        public int? FronterId { get; private set; }

        public string? CloserName { get; set; }
    }
}
