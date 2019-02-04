using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KingsmanTailors.API.Models
{
    public class Appointment
    {
        [Key]
        [Column("appointmentId")]
        public int AppointmentId { get; set; }

        [Required]
        [Column("appointmentDate")]
        public DateTime AppointmentDate { get; set; }

        [NotMapped]
        public DateTime AppointmentTime { get; set; }

        [Required]
        [Column("custName")]
        public string CustomerName { get; set; }

        [Column("custPhone")]
        public string CustomerPhone { get; set; }

        [Column("custEmail")]
        public string CustomerEmail { get; set; }

        [Column("isConfirmed")]
        public bool IsConfirmed { get; set; }

        [Column("salesRep")]
        public string SalesRepId { get; set; }

        // [ForeignKey("SalesRepId")]
        // public virtual User SalesPerson { get; set; }
    }
}
