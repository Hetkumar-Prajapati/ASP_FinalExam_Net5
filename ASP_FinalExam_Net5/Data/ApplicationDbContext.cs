using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ASP_FinalExam_Net5.Models;

namespace ASP_FinalExam_Net5.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ASP_FinalExam_Net5.Models.Department> Department { get; set; }
        public DbSet<ASP_FinalExam_Net5.Models.Employee> Employee { get; set; }
    }
}
