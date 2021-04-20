using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace On_boarding_API.Models
{
    public class ShippingAddress
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int ShippingId { get; set; }
        [Required]
        public int CustRegistrationId { get; set; }
        [Required]
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string District { get; set; }
        public string SpecificRegistrationRequest { get; set; }
        public Boolean Email { get; set; }

    }
}
