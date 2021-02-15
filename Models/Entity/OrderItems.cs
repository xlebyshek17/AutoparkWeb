using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoparkWeb.Models.Entity
{
    public class OrderItems
    {
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int DetailId { get; set; }
        [Required]
        public int DetailCount { get; set; }
        public Orders Order { get; set; }
        public SpareParts SparePart { get; set; }
    }
}
