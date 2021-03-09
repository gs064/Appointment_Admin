using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment_Admin.Models
{
    //This class shows all informatoin about my patient detail including name, adress,phone, dob and registration no etc// 
    public class patient
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
      
    }
}
