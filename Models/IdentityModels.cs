using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using EmpManager.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EmpManager.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {

            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Setting> Settings { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<ThemeSetting> ThemeSettings { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        

        public DbSet<Termination>Terminations { get; set; }
        

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Attendance> Attendances { get; set; }



        public DbSet<Payroll> Payrolls { get; set; }

        public DbSet<Holiday> Holidays { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<Income> Incomes { get; set; }
        public DbSet<Event> Events { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

       
    }
}