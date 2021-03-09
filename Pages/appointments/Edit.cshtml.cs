using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Appointment_Admin.Data;
using Appointment_Admin.Models;

namespace Appointment_Admin.Pages.appointments
{
    public class EditModel : PageModel
    {
        private readonly Appointment_Admin.Data.Appointment_AdminContext _context;

        public EditModel(Appointment_Admin.Data.Appointment_AdminContext context)
        {
            _context = context;
        }

        [BindProperty]
        public appointment appointment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            appointment = await _context.appointment
                .Include(a => a.Clinic)
                .Include(a => a.Doctor)
                .Include(a => a.Patient).FirstOrDefaultAsync(m => m.Id == id);

            if (appointment == null)
            {
                return NotFound();
            }
           ViewData["ClinicId"] = new SelectList(_context.clinic, "Id", "Clinic_address");
           ViewData["DoctorID"] = new SelectList(_context.doctor, "Id", "Email");
           ViewData["PatientID"] = new SelectList(_context.patient, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(appointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!appointmentExists(appointment.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool appointmentExists(int id)
        {
            return _context.appointment.Any(e => e.Id == id);
        }
    }
}
