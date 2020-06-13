using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Fenergo.Ui.Models;

namespace Fenergo.Ui.Repositories
{
    public class HardwareTypeRepository : IHardwareTypeRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<HardwareType> GetAll()
        {
            return db.HardwareTypes.ToList();
        }

        public HardwareType Get(int id)
        {
            return db.HardwareTypes.Find(id);
        }

        public HardwareType Update(HardwareType hardware)
        {
            db.Entry(hardware).State = EntityState.Modified;

            db.SaveChanges();
            return hardware;
        }

        public HardwareType Create(HardwareType hardware)
        {
            db.HardwareTypes.Add(hardware);
            db.SaveChanges();
            return hardware;
        }

        public HardwareType Delete(int id)
        {
            HardwareType hardware = db.HardwareTypes.Find(id);
            if (hardware == null)
            {
                return null;
            }

            db.HardwareTypes.Remove(hardware);
            db.SaveChanges();
            return hardware;
        }


        private bool HardwareTypeExists(int id)
        {
            return db.HardwareTypes.Count(e => e.Id == id) > 0;
        }
    }
}