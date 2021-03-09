using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Appointment_Admin.Models;

namespace Appointment_Admin.Data
{
    public class Appointment_AdminContext : DbContext
    {
        public Appointment_AdminContext (DbContextOptions<Appointment_AdminContext> options)
            : base(options)
        {
        }

        public DbSet<Appointment_Admin.Models.appointment> appointment { get; set; }

        public DbSet<Appointment_Admin.Models.clinic> clinic { get; set; }

        public DbSet<Appointment_Admin.Models.doctor> doctor { get; set; }

        public DbSet<Appointment_Admin.Models.patient> patient { get; set; }
    }
}
