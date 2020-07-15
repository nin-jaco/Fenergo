using System;
using System.Data.Entity;
using Fenergo.Ui.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Fenergo.Ui.Repositories
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<Photo> Photos { get; set; }
        DbSet<HardwareType> HardwareTypes { get; set; }
        DbSet<Hardware> Hardwares { get; set; }
        int SaveChanges();
        void MarkAsModified(Photo item);
        void MarkAsModified(Hardware item);
        void MarkAsModified(HardwareType item);
    }
}