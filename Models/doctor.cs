using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment_Admin.Models
{
    //this class use for disply the detail of doctor//
    public class doctor
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Sepicaligation { get; set; }
        [Required]
        public string Email { get; set; }
       public string Phone { get; set; }

    }
}
