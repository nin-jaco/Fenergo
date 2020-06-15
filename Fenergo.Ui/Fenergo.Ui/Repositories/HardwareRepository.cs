using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using Fenergo.Ui.Models;

namespace Fenergo.Ui.Repositories
{
    public class HardwareRepository : IHardwareRepository
    {
        private IApplicationDbContext db = new ApplicationDbContext();

        public HardwareRepository()
        {
            
        }

        public HardwareRepository(IApplicationDbContext context)
        {
            db = context;
        }

        public IEnumerable<Hardware> GetAll()
        {
            return db.Hardwares.Include("HardwareType").Include("Photo").ToList();
        }

        public Hardware Get(int id)
        {
            return db.Hardwares.Find(id);
        }

        public Hardware Update(Hardware hardware)
        {
            //db.Entry(hardware).State = EntityState.Modified;
            db.MarkAsModified(hardware);
            db.SaveChanges();
            return hardware;
        }

        public Hardware Create(Hardware hardware)
        {
            db.Hardwares.Add(hardware);
            db.SaveChanges();
            return hardware;
        }

        public Hardware Delete(int id)
        {
            Hardware hardware = db.Hardwares.Find(id);
            if (hardware == null)
            {
                return null;
            }

            db.Hardwares.Remove(hardware);
            db.SaveChanges();
            return hardware;
        }

        
        private bool HardwareExists(int id)
        {
            return db.Hardwares.Count(e => e.Id == id) > 0;
        }
    }
}