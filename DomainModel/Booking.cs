using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModel
{
    [Table("Booking")]
    public class Booking
    {
        public int BookingId { get; set; }

        [Range(typeof(DateTime), "01/01/2019", "01/01/3000")]
        [Required]
        public DateTime Created { get; set; }

        [Range(typeof(DateTime), "01/01/2019", "01/01/3000")]
        [Required]
        public DateTime CheckIn { get; set; }

        [Range(typeof(DateTime), "01/01/2019", "01/01/3000")]
        [Required]
        public DateTime CheckOut { get; set; }

        [Range(0d, double.MaxValue)]
        [Required]
        public decimal Price { get; set; }

        [Required]
        public bool IsPaid { get; set; }

        public virtual ICollection<BookingRoom> BookingRooms { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
