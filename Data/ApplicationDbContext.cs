using Microsoft.EntityFrameworkCore;
using InfoTechAcademy.Models;

namespace InfoTechAcademy.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Admission> Admissions { get; set; }
    }
}