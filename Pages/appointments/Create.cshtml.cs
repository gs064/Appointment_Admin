using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Appointment_Admin.Data;
using Appointment_Admin.Models;

namespace Appointment_Admin.Pages.appointments
{
    public class CreateModel : PageModel
    {
        private readonly Appointment_Admin.Data.Appointment_AdminContext _context;

        public CreateModel(Appointment_Admin.Data.Appointment_AdminContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClinicId"] = new SelectList(_context.clinic, "Id", "Clinic_address");
        ViewData["DoctorID"] = new SelectList(_context.doctor, "Id", "Email");
        ViewData["PatientID"] = new SelectList(_context.patient, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public appointment appointment { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.appointment.Add(appointment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
