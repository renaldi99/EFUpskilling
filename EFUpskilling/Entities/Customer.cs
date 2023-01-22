using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFUpskilling.Entities
{
    [Table(name:"mt_customer")]
    public class Customer
    {
        [Key, Column(name:"id")/*, DatabaseGenerated(DatabaseGeneratedOption.Identity)*/]
        public Guid Id { get; set; }
        [Column(name: "customer_name", TypeName = "NVarchar(50)")]
        [Required]
        public string CustomerName { get; set; } = String.Empty;
        [Column(name: "address", TypeName = "NVarchar(100)")]
        [Required]
        public string Address { get; set; } = String.Empty;
        [Column(name: "mobile_phone", TypeName = "NVarchar(14)")]
        [Required]
        public string MobilePhone { get; set; } = String.Empty;
        [Column(name: "email", TypeName = "NVarchar(100)")]
        [Required]
        public string Email { get; set; } = String.Empty;
    }
}
