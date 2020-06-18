using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fenergo.Ui.Models;

namespace Fenergo.Ui.Tests
{
    class TestHardwareDbSet :TestDbSet<Hardware>, IEnumerable<Hardware>
    {
        public override Hardware Find(params object[] keyValues)
        {
            return this.SingleOrDefault(p => p.Id == (int)keyValues.Single());
        }
    }
}
