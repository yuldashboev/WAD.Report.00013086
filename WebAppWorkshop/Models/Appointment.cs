using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppWorkshop.Models
{
    public class Appointment
    {
        public int id { get; set; }

        // foreign key
        [ForeignKey("receptionistID")]
        public int receptionistID { get; set; }
       
        [ForeignKey("visitorID")]
        public int visitorID { get; set; }

        // Navigation property
        public Receptionist? receptionist { get; set; }
        public Visitor? visitor { get; set; }

        public DateOnly? date { get; set; }
        public TimeOnly? time { get; set; }
        public String? purpose { get; set; }
        public String? status { get; set; }



    }
}
