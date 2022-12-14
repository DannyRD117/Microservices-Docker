using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Common
{
    public class EntityBase
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string? lastModifiedBy { get; set; }
        public DateTime? lastModifiedDate { get; set; }
    }
}
