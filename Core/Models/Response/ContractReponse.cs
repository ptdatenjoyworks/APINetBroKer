using Core.Models.Response.User;

namespace Core.Models.Response
{
    public class ContractReponse
    {

        public int Id { get; init; }
        public string? LegalEntityName { get; set; }
        public int? CloserId { get; private set; }
        public int? FronterId { get; private set; }

        public string CloserName { get; set; }
    }
}
