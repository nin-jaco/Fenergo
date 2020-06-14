using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fenergo.Ui.Models;

namespace Fenergo.Ui.Repositories
{
    public interface IHardwareTypeRepository
    {
        IEnumerable<HardwareType> GetAll();
        HardwareType Get(int id);
        HardwareType Update(HardwareType hardwareType);
        HardwareType Create(HardwareType hardwareType);
        HardwareType Delete(int id);
    }
}