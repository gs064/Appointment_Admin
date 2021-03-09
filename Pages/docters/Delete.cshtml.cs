using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Appointment_Admin.Data;
using Appointment_Admin.Models;

namespace Appointment_Admin.Pages.docters
{
    public class DeleteModel : PageModel
    {
        private readonly Appointment_Admin.Data.Appointment_AdminContext _context;

        public DeleteModel(Appointment_Admin.Data.Appointment_AdminContext context)
        {
            _context = context;
        }

        [BindProperty]
        public doctor doctor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            doctor = await _context.doctor.FirstOrDefaultAsync(m => m.Id == id);

            if (doctor == null)
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

            doctor = await _context.doctor.FindAsync(id);

            if (doctor != null)
            {
                _context.doctor.Remove(doctor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
