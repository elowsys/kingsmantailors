using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KingsmanTailors.API.Models
{
    public class AppointmentDetail
    {
        [Key]
        [Column("appointmentDetailId")]
        public int AppointmentDetailId { get; set; }

        [Column("appointmentId")]
        public int AppointmentId { get; set; }

        [ForeignKey("AppointmentId")]
        public virtual Appointment Appointment { get; set; }

        [Column("detailId")]
        public int DetailId { get; set; }

        [ForeignKey("DetailId")]
        public virtual SuitDetail SuitDetail { get; set; }
    }
}
