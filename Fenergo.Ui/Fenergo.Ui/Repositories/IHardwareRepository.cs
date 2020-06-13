using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fenergo.Ui.Models;

namespace Fenergo.Ui.Repositories
{
    public interface IHardwareRepository
    {
        IEnumerable<Hardware> GetAll();
        Hardware Get(int id);
        Hardware Update(Hardware hardware);
        Hardware Create(Hardware hardware);
        Hardware Delete(int id);
    }
}