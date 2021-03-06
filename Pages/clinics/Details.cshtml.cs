using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Appointment_Admin.Data;
using Appointment_Admin.Models;

namespace Appointment_Admin.Pages.clinics
{
    public class DetailsModel : PageModel
    {
        private readonly Appointment_Admin.Data.Appointment_AdminContext _context;

        public DetailsModel(Appointment_Admin.Data.Appointment_AdminContext context)
        {
            _context = context;
        }

        public clinic clinic { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            clinic = await _context.clinic.FirstOrDefaultAsync(m => m.Id == id);

            if (clinic == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
