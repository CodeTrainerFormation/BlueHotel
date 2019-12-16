using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModel
{
    [Table("Customer")]
    public class Customer
    {
        public int CustomerId { get; set; }

        [StringLength(255)]
        [Required]
        public string FullName { get; set; }

        [Range(typeof(DateTime), "01/01/1900", "31/12/2020")]
        [Required]
        public DateTime DateOfBirth { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
