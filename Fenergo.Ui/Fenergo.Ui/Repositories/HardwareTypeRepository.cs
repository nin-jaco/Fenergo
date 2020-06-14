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

        public HardwareType Update(HardwareType hardwareType)
        {
            db.Entry(hardwareType).State = EntityState.Modified;

            db.SaveChanges();
            return hardwareType;
        }

        public HardwareType Create(HardwareType hardwareType)
        {
            db.HardwareTypes.Add(hardwareType);
            db.SaveChanges();
            return hardwareType;
        }

        public HardwareType Delete(int id)
        {
            HardwareType hardwareType = db.HardwareTypes.Find(id);
            if (hardwareType == null)
            {
                return null;
            }

            db.HardwareTypes.Remove(hardwareType);
            db.SaveChanges();
            return hardwareType;
        }


        private bool HardwareTypeExists(int id)
        {
            return db.HardwareTypes.Count(e => e.Id == id) > 0;
        }
    }
}