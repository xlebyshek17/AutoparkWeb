using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoparkWeb.Models.Entity
{
    public class OrderItems
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int DetailId { get; set; }
        public int DetailCount { get; set; }
        public Orders Order { get; set; }
        public SpareParts SparePart { get; set; }
    }
}
