using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModel
{
    [Table("Address")]
    public class Address
    {
        public int AddressId { get; set; }

        [StringLength(255)]
        [Required]
        public string Street { get; set; }

        [StringLength(10)]
        [Required]
        public string ZipCode { get; set; }

        [StringLength(50)]
        [Required]
        public string City { get; set; }

        [StringLength(55)]
        [Required]
        public string Country { get; set; }

        /// <summary>
        /// range of -90 à 90 
        /// </summary>
        public double? Latitude { get; set; }

        /// <summary>
        /// range of -180 à 180
        /// </summary>
        public double? Longitude { get; set; }

        [Required]
        [StringLength(14)]
        [RegularExpression(@"\+(9[976]\d|8[987530]\d|6[987]\d|5[90]\d|42\d|3[875]\d|2[98654321]\d|9[8543210]|8[6421]|6[6543210]|5[87654321]|4[987654310]|3[9643210]|2[70]|7|1)\d{1,14}$")]
        public string Phone { get; set; }

        [Required]
        [StringLength(255)]
        [RegularExpression(@"^\w + ([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")]
        public string Email { get; set; }
    }
}
