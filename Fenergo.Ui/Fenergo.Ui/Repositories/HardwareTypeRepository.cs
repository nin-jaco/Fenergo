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
        private IApplicationDbContext _applicationDbContext;

        public HardwareTypeRepository()
        {
            _applicationDbContext = new ApplicationDbContext();
        }

        public HardwareTypeRepository(IApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public IEnumerable<HardwareType> GetAll()
        {
            return _applicationDbContext.HardwareTypes.ToList();
        }

        public HardwareType Get(int id)
        {
            return _applicationDbContext.HardwareTypes.Find(id);
        }

        public HardwareType Update(HardwareType hardwareType)
        {
            _applicationDbContext.MarkAsModified(hardwareType);

            _applicationDbContext.SaveChanges();
            return hardwareType;
        }

        public HardwareType Create(HardwareType hardwareType)
        {
            _applicationDbContext.HardwareTypes.Add(hardwareType);
            _applicationDbContext.SaveChanges();
            return hardwareType;
        }

        public HardwareType Delete(int id)
        {
            HardwareType hardwareType = _applicationDbContext.HardwareTypes.Find(id);
            if (hardwareType == null)
            {
                return null;
            }

            _applicationDbContext.HardwareTypes.Remove(hardwareType);
            _applicationDbContext.SaveChanges();
            return hardwareType;
        }


        private bool HardwareTypeExists(int id)
        {
            return _applicationDbContext.HardwareTypes.Count(e => e.Id == id) > 0;
        }
    }
}