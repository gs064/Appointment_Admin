using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Appointment_Admin.Data;
using Appointment_Admin.Models;

namespace Appointment_Admin.Pages.patients
{
    public class DeleteModel : PageModel
    {
        private readonly Appointment_Admin.Data.Appointment_AdminContext _context;

        public DeleteModel(Appointment_Admin.Data.Appointment_AdminContext context)
        {
            _context = context;
        }

        [BindProperty]
        public patient patient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            patient = await _context.patient.FirstOrDefaultAsync(m => m.Id == id);

            if (patient == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            patient = await _context.patient.FindAsync(id);

            if (patient != null)
            {
                _context.patient.Remove(patient);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
