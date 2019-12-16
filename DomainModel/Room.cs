using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModel
{
    [Table("Room")]
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }

        [StringLength(30)]
        [Required]
        public string Name { get; set; }

        [Range(0, 200)]
        [Required]
        public int Floor { get; set; }
        
        [StringLength(50)]
        public string Category { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual ICollection<BookingRoom> BookingRooms { get; set; }
    }
}
