using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Fenergo.Ui.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Fenergo.Ui.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public DbSet<Photo> Photos { get; set; }
        public DbSet<HardwareType> HardwareTypes { get; set; }
        public DbSet<Hardware> Hardwares { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public void MarkAsModified(Hardware item)
        {
            Entry(item).State = EntityState.Modified;
        }

        public void MarkAsModified(Photo item)
        {
            Entry(item).State = EntityState.Modified;
        }
    }
}