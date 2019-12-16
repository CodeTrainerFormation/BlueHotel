using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModel
{
    [Table("Hotel")]
    public class Hotel
    {
        //propriétés scalaires
        public int HotelId { get; set; }

        [StringLength(30)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int Star { get; set; }

        //propriétés de navigations
        public virtual Address Address { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
