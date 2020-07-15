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
        private IApplicationDbContext _applicationDbContext;

        public HardwareRepository()
        {
            _applicationDbContext = new ApplicationDbContext();
        }

        public HardwareRepository(IApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public IEnumerable<Hardware> GetAll()
        {
            return _applicationDbContext.Hardwares.Include("HardwareType").Include("Photo").ToList();
        }

        public Hardware Get(int id)
        {
            return _applicationDbContext.Hardwares.Find(id);
        }

        public Hardware Update(Hardware hardware)
        {
            //db.Entry(hardware).State = EntityState.Modified;
            _applicationDbContext.MarkAsModified(hardware);
            _applicationDbContext.SaveChanges();
            return hardware;
        }

        public Hardware Create(Hardware hardware)
        {
            _applicationDbContext.Hardwares.Add(hardware);
            _applicationDbContext.SaveChanges();
            return hardware;
        }

        public Hardware Delete(int id)
        {
            Hardware hardware = _applicationDbContext.Hardwares.Find(id);
            if (hardware == null)
            {
                return null;
            }

            _applicationDbContext.Hardwares.Remove(hardware);
            _applicationDbContext.SaveChanges();
            return hardware;
        }

        
        private bool HardwareExists(int id)
        {
            return _applicationDbContext.Hardwares.Count(e => e.Id == id) > 0;
        }
    }
}