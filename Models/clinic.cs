using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment_Admin.Models
{
    //this class contain information about clinic//
    public class clinic
    {
      
        public int Id { get; set; }
        [Required]
        public string Clinic_name { get; set; }
        [Required]
        public string Clinic_address { get; set; }
        
        public string Clinic_phone { get; set; }
       
    }
}
