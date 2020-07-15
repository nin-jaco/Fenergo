using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Fenergo.Ui.Models;
using Fenergo.Ui.Repositories;

namespace Fenergo.Ui.Tests
{
    public class TestAppContext : IApplicationDbContext
    {
        public TestAppContext()
        {
            this.Hardwares = new TestHardwareDbSet();
        }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<HardwareType> HardwareTypes { get; set; }
        public DbSet<Hardware> Hardwares { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Photo item)
        {
            
        }

        public void MarkAsModified(Hardware item)
        {
            
        }

        public void MarkAsModified(HardwareType item)
        {
            
        }

        public void Dispose()
        {

        }
    }
}
