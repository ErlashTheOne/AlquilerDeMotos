using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MotorcycleRent.Models;

namespace MotorcycleRent.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MotorcycleRent.Models.Motorcycle> Motorcycle { get; set; }
        public object AppUser { get; internal set; }
        public DbSet<MotorcycleRent.Models.Booking> Booking { get; set; }
    }
}
