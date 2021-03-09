using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment_Admin.Models
{
    //this class contain  information about relation between other class through this class//
    public class appointment
    {

        public int Id { get; set; }

        public int ClinicId { get; set; }
        public clinic Clinic { get; set; }
        public int DoctorID { get; set; } 
        public doctor Doctor { get; set; }
        public int PatientID { get; set; }
        public patient Patient { get; set; }
        public DateTime Appointment_date_time { get; set; }

    }
}