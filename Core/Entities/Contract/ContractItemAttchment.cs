using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Contract
{
    public class ContractItemAttchment
    {
        [Column("Id")]
        public int? Id { get; set; }
        public string Path { get; set; }

        public int ContractItemId { get; set; }
        public ContractItem ContractItem { get; set; }
    }
}
