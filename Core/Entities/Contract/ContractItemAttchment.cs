using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Contract
{
    public class ContractItemAttchment
    {
        public ContractItemAttchment(string path, int contractItemId)
        {
            Path = path;
            ContractItemId = contractItemId;
        }

        [Column("Id")]
        public int Id { get; private set; }
        public string Path { get; private set; }

        public int ContractItemId { get; private set; }
        public ContractItem ContractItem { get; private set; }

    }


}
