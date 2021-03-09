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
    public class IndexModel : PageModel
    {
        private readonly Appointment_Admin.Data.Appointment_AdminContext _context;

        public IndexModel(Appointment_Admin.Data.Appointment_AdminContext context)
        {
            _context = context;
        }

        public IList<doctor> doctor { get;set; }

        public async Task OnGetAsync()
        {
            doctor = await _context.doctor.ToListAsync();
        }
    }
}
