using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Contract
{
    public class ApplicationUsers
    {
        [Column("Id")]
        public int? Id { get; init; }

        public int? Closer { get; private set; }
        public int? Fronter { get; private set; }
        public ICollection<Contract>? Contracts { get; private set; }
        public ApplicationUsers(int? closer, int? fronter)
        {
            Closer = closer;
            Fronter = fronter;
        }
    }
}
