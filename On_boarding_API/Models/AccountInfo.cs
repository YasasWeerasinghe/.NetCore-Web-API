using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace On_boarding_API.Models
{
    public class AccountInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int CustRegistrationId { get; set; }
        [MinLength(3)]
        public string ContactPerson { get; set; }     
        public string BusinessName { get; set; }      
        public int ContactNumber { get; set; }
        [Required]
        public string StreetAddress1 { get; set; }      
        public string StreetAddress2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime StratDate { get; set; }

    }
}
