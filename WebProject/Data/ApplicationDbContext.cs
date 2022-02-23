using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebProject.Models;

namespace WebProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebProject.Models.Student> Student { get; set; }
        public DbSet<WebProject.Models.Courses> Courses { get; set; }
        public DbSet<WebProject.Models.Enrol> Enrol { get; set; }
        public DbSet<WebProject.Models.EnrolName> EnrolName { get; set; }
        public DbSet<WebProject.Models.Etwo> Etwo { get; set; }
        
    }
}
